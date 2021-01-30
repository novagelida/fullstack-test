<template>
    <transition name="modal">
        <div class="modal-mask">
          <div class="modal-wrapper">
            <div class="modal-container">

              <div class="modal-header">
                <span class="close-modal-button" @click="$emit('close-modal')">x</span>
                <slot name="header">
                  default header
                </slot>
              </div>

              <div class="modal-body" >
                <slot name="body">
                </slot>
              </div>
            </div>
          </div>
        </div>
      </transition>
</template>
<style>
.modal-mask {
  position: fixed;
  z-index: 9998;
  top: 0;
  left: 0;
  width: 100%;
  height: 100%;
  background-color: rgba(0, 0, 0, 0.5);
  display: table;
  transition: opacity 0.3s ease;
}

.modal-wrapper {
  display: table-cell;
  vertical-align: middle;
}

.modal-header
{
  display: flex;
  flex-direction: column;
}

.modal-container {
  width: fit-content;
  margin: 0px auto;
  padding: 20px 50px 50px 50px;
  background-color: #fff;
  border-radius: 2px;
  box-shadow: 0 2px 8px rgba(0, 0, 0, 0.33);
  transition: all 0.3s ease;
  font-family: Helvetica, Arial, sans-serif;
}

.modal-header h3 {
  margin-top: 0;
  font: normal normal 900 22px/22px "Avenir Book";
  letter-spacing: 0px;
  color: #000000;
  text-align: center;
}

.modal-body {
  margin: 20px 0;
}

.modal-default-button {
  float: right;
}

.modal-mask .close-modal-button
{
  cursor: pointer;
  align-self: flex-end;
}

.modal-mask .close-modal-button:hover
{
  color: #00000080;
}

.modal-enter {
  opacity: 0;
}

.modal-leave-active {
  opacity: 0;
}

.modal-enter .modal-container,
.modal-leave-active .modal-container {
  -webkit-transform: scale(1.1);
  transform: scale(1.1);
}
</style>