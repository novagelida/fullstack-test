import Vuex from 'vuex';
import Vue from 'vue';

Vue.use(Vuex);

export const store = new Vuex.Store({
    state: {
        productViewContext: {
            comparisonList: [],
            comparisonBannerDisplayed: false,
            comparisonEnabled: false,
            comparisonModalActive: false,
            productList : {}
        }
      },
      mutations: {
            addToComparisonList (state, id) {
                state.productViewContext.comparisonList.push(id);
                state.productViewContext.comparisonBannerDisplayed = true;
            },
            removeFromComparisonList(state, id){
                state.productViewContext.comparisonList.splice(state.productViewContext.comparisonList.indexOf(id, 0), 1);
                if (state.productViewContext.comparisonList.length < 1)
                    state.productViewContext.comparisonBannerDisplayed = false;
            },
            enableComparison() {
                this.state.productViewContext.comparisonEnabled = true;
            },
            disableComparison() {
                this.state.productViewContext.comparisonEnabled = false;
            },
            showComparisonModal() {
                this.state.productViewContext.comparisonModalActive = true;
            },
            hideComparisonModal() {
                this.state.productViewContext.comparisonModalActive = false;
            },
            setProductList(state, plist) {
                var products = {};
                plist.map(p => products[p.id] = p);
                state.productViewContext.productList = products;
            }
      }
  });