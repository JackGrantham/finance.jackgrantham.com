var transactionsGridRepo = (function () {
    function transactionsGridRepo() {
        const self = this;

        this.width = "100%";
        this.height = "auto";
        this.inserting = false;
        this.editing = false;
        this.sorting = false;
        this.paging = false;
        this.pageSize = 10;
        this.pageButtonCount = 5;
        this.filtering = false;
        this.autoLoad = true;

        this.fieldList = [
            {
                name: "Description", title: "Description", type: "text"
            },
            {
                name: "Description", title: "Description", type: "text"
            },
            {
                name: "Description", title: "Description", type: "text"
            },
            {
                name: "Description", title: "Description", type: "text"
            },
            //{
            //    type: "control",
            //    editButton: false,
            //    deleteButton: false,
            //}
        ];

        this.loadData = function (filter) {
            return $.ajax({
                type: 'GET',
                url: "",
                data: filter,
                dataType: 'json',
            });
        };

        this.rowClick = function () {
            // Implement
        };

        this.initialize = function () {
            const options =
            {
                width: self.width,
                height: self.height,
                filtering: self.filtering,
                inserting: self.inserting,
                editing: self.editing,
                sorting: self.sorting,
                paging: self.paging,
                autoLoad: self.autoLoad,
                pageSize: self.pageSize,
                pageButtonCount: self.pageButtonCount,
                rowClock: this.rowClick,
                controller:
                {
                    loadData: self.loadData
                },
                fields: self.fieldList,

                // Make Horizontal Scrollbar Persistent w/ No Data
                //noDataContent: function () {
                //    var location = $('#Transactions .jsgrid-grid-header');
                //    location.removeClass('jsgrid-header-scrollbar');
                //    return 'Not Found';
                //},
                //onDataLoading: function () {
                //    var location = $('#Transactions .jsgrid-grid-header');
                //    location.addClass('jsgrid-header-scrollbar');
                //},
                //onItemInserted: function () {
                //    var location = $('#Transactions .jsgrid-grid-header');
                //    location.addClass('jsgrid-header-scrollbar');
                //},
            };

            return options;
        };

    }

    return transactionsGridRepo;
})();