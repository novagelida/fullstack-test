# Getting started

1) Clona il repo
2) ``docker-compose build``
3) ``docker-compose -f .\docker-compose.yml up``
4) naviga su http://localhost:81/
5) swagger è qui http://localhost:81/api/swagger/

### Comandi Docker
Ho effettuato i miei test con questa modalità


Comandi:

* ``docker-compose build``: prepara i container e compila le soluzioni;
* ``docker-compose -f .\docker-compose.yml up`` avvia i contanier come ambienti di produzione;

* ``docker-compose up`` avvia i container come ambienti di sviluppo.

Porte Esposte:

* http://localhost:8080/ > dashboard traefik;
* http://localhost:81/ > **client: attraverso traefik**;
* http://localhost:75/ > client: accesso diretto al container;
* http://localhost:76/ > api: accesso diretto al container;
* http://localhost:81/api > api: attraverso traefik.

### Avviare da terminale

Comandi:

* dalla cartella ``./frontend``, 
>``npm run serve`` compila e hosta il client su http://localhost:8080
* dalla cartella ``./api/ApiServer``, 
>``dotnet run ApiServer.sln`` avvia il backend su http://localhost:5000

## Task

Creare una Web Application, usando i propri strumenti di sviluppo preferiti, che risponda alle seguenti caratteristiche:

  

-   Deve ripercorrere in modo fedele (pixel perfect) la grafica disponibile al link: [http://adobe.ly/2KzrvkM](http://adobe.ly/2KzrvkM)
    
-   Sarà possibile il salvataggio di prodotti in wishlist (localStorage) dando un feedback di avvenuta aggiunta (cuore diventa rosso)
    
-   Sarà possibile inserire i prodotti in lista per la comparazione.  
    Al primo prodotto selezionato: si attiverà il banner che comparirà con una transizione dal basso e sarà fixed rispetto alla pagina.  
    Al terzo prodotto selezionato: il bottone confronta diverrà attivo e al click farà comparire una modale (non presente in grafica).
    
-   Ha una paginazione e dei filtri applicabili ai prodotti, che vanno realizzati graficamente, ma la cui logica può anche non essere implementata.

## Cosa ho fatto

Ho iniziato a realizzare i task impostando la struttura della pagina. Una volta soddisfatto con la struttura ho aggiunto ``vue`` e a poco a poco ho iniziato a realizzare i componenti in maniera iterativa, avendo sempre qualcosa di funzionante a schermo. 

Nel frattempo ho deciso di creare un backend con cui far interagire il client ``vue`` che stavo scrivendo.

Ho quindi realizzato una piccola infrastruttura con [Docker](https://www.docker.com/get-started). Tramite il file ``docker-compose.yml``, Docker crea tre container: ``traefik``, ``frontend``, ``api``.

* **traefik** è un load balancer che permette a ``frontend`` e ``api`` di dialogare;
* **frontend** è il contaner che compila il frontend e lo serve tramite nginx;
* **api** è un container su cui viene eseguita l'applicazione *ApiServer*. *ApiServer* è un appilcazione ``.net core`` che espone le api che vengono chiamate dal frontend.

### **Client: Features**

Il client segue le specifiche illustrate in ***Task***. I filtri e i controlli di pagina del client sono solo dei mock e non eseguono alcuna logica.

Il client è del tutto componentizzato. Il componente ``product-card`` è del tutto dinamico e permette di visualizzare la scheda di un qualunque prodotto.

Quando la pagina viene eseguita, il client effettua un login con il backend. Dopo aver effettuato il login, il client chiede una lista prodotti al backend.

Una volta ricevuti i prodotti, le schede prodotto vengono renderizzate.

>**NOTA:** avendo a dispozione una sola foto, tutte le schede prodotto mostrano la stessa immagine.

#### **Limitazioni**

* Non ho pensato a nessuna soluzione di immediato sviluppo per ovviare al problema del numero massimo di schede prodotto visualizzate nella modale di comparazione. Il massimo numero di product card visualizzabili decentemente in modale è 5;
* Non sono riuscito a ricavare un'immagine da sovrapporre alla pagina che ho creato. Non potendo esportare un'immagine da [http://adobe.ly/2KzrvkM](http://adobe.ly/2KzrvkM), non ho potuto effettuare alcun test con [questo strumento](https://chrome.google.com/webstore/detail/pixelparallel-by-htmlburg/iffnoibnepbcloaaagchjonfplimpkob).

#### **Possibili migliorie**

* Le checkbox non sono degli input e invece dovrebbero esserlo. Ho preferito usare dei div per avere meno problemi con lo stile;
* Si potrebbero implementare delle color variables o in css o tramite lo store di vue;
* I controlli di pagina sono facilmente implementabili perchè le api supportano già la paginazione;
* Per far funzionare i filtri servirebbe implementare la ricerca prodotto lato backend. Non mi piaceva l'idea di filtrare i dati lato frontend perchè, ricevendo contenuto paginato, sarebbe stato possibile filtrare solo la parte di prodotti che il client ha ricevuto in quel momento. Non si sarebbe potuto filtrare su tutti i prodotti.
* Alcune props di certi componenti dovrebbero essere obbligatorie;
* E' possibile testare i componenti con [vtu](https://vue-test-utils.vuejs.org/guides/getting-started.html).

### **Api: Features**

Il server espone gli endpoints ``Boilers`` e ``Login``. 

* Tramite ``get`` Boilers vengono restituiti i prodotti. ``get Boilers`` prevede dei parametri opzionali per effettuare una richiesta paginata.

* ``Login`` serve ad autenticare il client e fornire un token di autorizzazione. *Senza aver effettuato il login non è possibile inviare richieste a* ``Boilers``.

Le api sono documentate tramite swagger all'indirizzo: [http://localhost:81/api/swagger/](http://localhost:81/api/swagger/).

Le richieste vengono messe in cache (in memory) e l'header ``cache control`` viene impostato nelle risposte. Viene impostato anche l'header di versione.

La durata della cache, così come il master secret per l'autenticazione sono configurabili tramite ``appsettings.json``.

Ho utilizzato [LiteDb](https://www.litedb.org/docs/getting-started/) per organizzare i dati in un semplice database contenente: ``users`` e ``boilers``.

>**NOTA**: Usare swagger per testare le api non è una buona idea. Swagger utilizza una cache interna e questo comporta diversi disagi in fase di test. Per effettuare i test ho usato [Postman](https://www.postman.com/).
>
>* [Le mie richieste di test](https://www.getpostman.com/collections/07080c872783a436d44c)
>* ``localhost.postman_environment.json`` e ``Docker.postman_environment.json`` sono gli ambienti (unica differenza: variabile hostname) che ho usato

#### **Possibili migliorie**

* Ignorare connessioni http in favore di https tramite traefik (genera automaticamente certificati ssl ma è necessario associare un email);
* Usare un vero database ed entity framework;
* Autenticazione tramite [OpenID](https://openid.net/connect/);
* Avere un container dedicato al database;
* Avere una cache persistente, tipo [Redis](https://redis.io/clients#c-sharp), in un suo container.
