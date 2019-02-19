new Vue({
    el: '#app',
    data: {
        initialValues: '',
        list: [],

        orders: [
            {
                id: 0,
                text: 'nessun ordinamento',
            },
            {
                id: 1,
                text: 'prezzo crescente',
            },
            {
                id: 2,
                text: 'prezzo decrescente',
            },
            {
                id: 3,
                text: 'anno crescente',
            },
            {
                id: 4,
                text: 'anno decrescente',
            }
        ],
        selectedOrderId: 0
    },


    computed: {
        sorted_items: function () {

            switch (this.selectedOrderId) {
                case 1:
                    return this.list.sort(function (a, b) {
                        return a.price - b.price;
                    });

                case 2:
                    return this.list.sort(function (a, b) {
                        return b.price - a.price;
                    });

                case 3:
                    return this.list.sort(function (a, b) {
                        return a.year - b.year;
                    });

                case 4:
                    return this.list.sort(function (a, b) {
                        return b.year - a.year;
                    });

                default:
                    return this.list;
            }

        }
    },

    methods: {

        setList: function(items) {
            this.list = items;
        },

        selectOrder: function(orderId) {
            this.selectedOrderId = orderId;
        }

    }
});