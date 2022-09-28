{
    const baseUrl = "https://localhost:5001";
    const currentPage = 1;
    const dataTable =  document.getElementById("dataTable");
    const inputs = document.querySelectorAll(".datainput");
    const slider = document.getElementById("errorsCountSlider");
    const textInput = document.getElementById("errorsCountText");
    const regionSelect = document.getElementById("regionInput");
    const table = document.getElementById("dataTable").getElementsByTagName('tbody')[0];

    textInput.onkeyup = (event) => {        
        if(Number.isInteger(Number(event.target.value))){            
            slider.value = event.target.value / 10;
        }
        else{
            slider.value = 0;
        }
    }

    slider.onchange = (event) =>{
        textInput.value = event.target.value * 10;
    }

    const getData = async () =>{
        let url = new URL("Home/GetData", baseUrl);
        url.searchParams.append("region", regionSelect.value);
        url.searchParams.append("mistakesCount", slider.value);
        url.searchParams.append("pageNumber", currentPage);

        let response = await fetch(url)
            .then(response => response.json());
            
        console.log(response);

        response.forEach((item) => {
           let row = table.insertRow(dataTable.rows.length - 1);

           let idCell = row.insertCell();          
           idCell.appendChild(document.createTextNode(item.id));

           let nameCell = row.insertCell();           
           nameCell.appendChild(document.createTextNode(item.fullName));

           let addressCell = row.insertCell();
           addressCell.appendChild(document.createTextNode(`${item.region}, ${item.city} ${item.streetAddress}`));

           let phoneCell = row.insertCell();
           phoneCell.appendChild(document.createTextNode(item.phoneNumber));
        });

    }

    handleInputChange = () => {
        document.getElementsByTagName("tbody")[0].innerHTML = "";        
        getData();
    }

    inputs.forEach(input => {
        input.addEventListener("click", handleInputChange);
    });
}
