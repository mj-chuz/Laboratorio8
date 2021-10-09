
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
                let htmlContent = '';
                let row = '';
                let body = document.getElementById("ProductsContext");
                let tbl = document.createElement("table");
                let tblBody = document.createElement("tbody");
                for (const object of data) {
                    var fila = document.createElement("tr");
                    for (const key in object) {
                        row += `${object[key]} `

                    }
                    var columna = document.createElement("td");
                    htmlContent = document.createTextNode(row);
                    columna.appendChild(htmlContent);
                    fila.appendChild(columna);
                    tblBody.appendChild(fila);
                    row = '';
                }
                tbl.appendChild(tblBody)
                tbl.setAttribute("border", "2");
                body.appendChild(tbl);

            })
            .catch(error => {
                console.log(error);
            })
    }
}
