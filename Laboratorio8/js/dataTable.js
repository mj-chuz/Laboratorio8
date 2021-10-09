class DataTable {
    constructor(dataOrigin, context) {
        this.dataOrigin = dataOrigin;
        this.context = context;
    }

    fillContext() {
        fetch(this.dataOrigin)
            .then(response => {
                return response.json();
            })
            .then(data => {
                var tableData = data;
                var table = new Tabulator("#ProductsContext", {
                    data: tableData, 
                    autoColumns: true,
                });
            })
            .catch(error => {
                console.log(error);
            })
    }
}

