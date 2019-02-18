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