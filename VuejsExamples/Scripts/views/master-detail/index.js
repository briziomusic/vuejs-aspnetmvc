new Vue({
    el: '#master-detail',
    data: {
        antiforgeryToken: '',
        fetchProvinceUrl: '',
        fetchRegioniUrl: '',

        regioni: [],
        province: [],
        selectedRegione: 'Tutte'
    },


    beforeMount: function () {

        // get parameters from view
        this.antiforgeryToken = this.$el.attributes['antiforgery-token'].value;
        this.fetchProvinceUrl = this.$el.attributes['fetch-province-url'].value;
        this.fetchRegioniUrl = this.$el.attributes['fetch-regioni-url'].value;

        this.fetchRegioni();
        this.fetchProvince();
    },


    watch: {

        selectedRegione: function () {
            this.fetchProvince();
        }

    },


    methods: {

        fetchRegioni: function () {

            var formData = new FormData();
            formData.append('__RequestVerificationToken', this.antiforgeryToken);

            this.$http.post(this.fetchRegioniUrl, formData)
                .then(function (response) {
                    if (typeof (response) != 'undefined' && response.data.isSuccess === true) {
                        this.regioni = [];
                        this.regioni.push(
                            {
                                "Key": "Tutte",
                                "Value": ""
                            }
                        )
                        for (var i = 0; i < response.data.data.length; i++) {
                            this.regioni.push(response.data.data[i]);
                        }
                    }
                    else {
                        console.error('Invalid response');
                        this.regioni = [];
                    }

                }, function (response) {
                    // Error
                    console.error('An error occured in a request: ' + JSON.stringify(response));
                });

        },

        fetchProvince: function () {

            var formData = new FormData();
            formData.append('__RequestVerificationToken', this.antiforgeryToken);
            formData.append('regione', this.selectedRegione);

            this.$http.post(this.fetchProvinceUrl, formData)
                .then(function (response) {
                    if (typeof (response) != 'undefined' && response.data.isSuccess === true) {
                        this.province = response.data.data;
                    }
                    else {
                        console.error('Invalid response');
                        this.province = [];
                    }

                }, function (response) {
                    // Error
                    console.error('An error occured in a request: ' + JSON.stringify(response));
                });

        }


    }

});