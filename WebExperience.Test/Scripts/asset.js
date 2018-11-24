//(function () {
//    var app = angular.module('myApp', ['datatables']);
//    app.controller('homeCtrl', ['$scope', '$http', 'DTOptionsBuilder', 'DTColumnBuilder',
//        function ($scope, $http, DTOptionsBuilder, DTColumnBuilder) {
//            $scope.dtColumns = [
//                //here We will add .withOption('name','column_name') for send column name to the server 
//                DTColumnBuilder.newColumn("asset_id", "Customer ID").withOption('asset_id', 'asset_id'),
//                DTColumnBuilder.newColumn("file_name", "Company Name").withOption('file_name', 'file_name'),
//            ]

//            $scope.dtOptions = DTOptionsBuilder.newOptions().withOption('ajax', {
//                dataSrc: "data",
//                url: "/home/getdata",
//                type: "POST"
//            })
//                .withOption('processing', true) //for show progress bar
//                .withOption('serverSide', true) // for server side processing
//                .withPaginationType('full_numbers') // for get full pagination options // first / last / prev / next and page numbers
//                .withDisplayLength(10) // Page size
//                .withOption('aaSorting', [0, 'asc']) // for default sorting column // here 0 means first column
//        }])
//});
