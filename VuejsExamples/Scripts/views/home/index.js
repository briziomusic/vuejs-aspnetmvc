// jumbotron vue instance
new Vue({
    el: '#jumbotron-section',
    data: {
        initialJumbotronValues: '',
        jumbotronObj: {}
    },
    mounted: function () {
        console.log("jumbotron-section is mounted");
    },
    methods: {
        /* This is a method to pass the vm directly to vue instance */
        setJumbotronValues: function (vm) {
            this.jumbotronObj = vm;
        }
    }
});

// jumbotron2 vue instance
new Vue({
    el: '#jumbotron-section2',
    data: {
        title: '',
        description: ''
    },
    methods: {
        setJumbotronValues: function (vm) {
            this.title = vm.JumbotronTitle;
            this.description = vm.JumbotronDescription;
        }
    }
});

new Vue({
    el: "#http-post-to-controller-with-list",
    
    data: {
        antiforgeryToken: '',
        getListUrl: '',
        list: []
    },

    created: function () {
        console.log('http-post-to-controller-with-list is now created. Fetch list to controller'); 
    },

    beforeMount: function () {

        // get parameters from view
        this.antiforgeryToken = this.$el.attributes['antiforgery-token'].value;
        this.getListUrl = this.$el.attributes['get-list-url'].value;

        this.fetchListToController();
    },

    methods: {

        fetchListToController: function () {
            var formData = new FormData();
            formData.append('__RequestVerificationToken', this.antiforgeryToken);
            formData.append('someParameter', 'this is a parameter');

            this.$http.post(this.getListUrl, formData)
                .then(function (response) {
                    if (typeof (response) != 'undefined' && response.data.isSuccess === true) {
                        this.list = response.data.data;
                    }
                    else {
                        console.error('Invalid response');
                        this.list = [];
                    }

                }, function (response) {
                    // Error
                    console.error('An error occured in a request: ' + JSON.stringify(response));
                });

        }

    }
})