{
    const baseUrl = "https://localhost:5001";    
    const dataTable =  document.getElementById("dataTable");
    const slider = document.getElementById("errorsCountSlider");
    const textInput = document.getElementById("errorsCountText");
    const regionSelect = document.getElementById("regionInput");
    const table = document.getElementById("dataTable").getElementsByTagName('tbody')[0];
    const seedInput = document.getElementById("seedInput");
    const randomSeed = document.getElementById("randomSeed");
    
    let currentPage = 1;
    let currentData = [];

    const getRandomInt = (max) =>{
        return Math.floor(Math.random() * max);
    }

    const getData = async () =>{
        let url = new URL("Home/GetData", baseUrl);
        url.searchParams.append("region", regionSelect.value);
        url.searchParams.append("mistakesCount", slider.value);
        url.searchParams.append("pageNumber", currentPage);
        url.searchParams.append("seed", seedInput.value);

        let response = await fetch(url)
            .then(response => response.json());

        response.forEach((item) => {
           currentData.push(item); 
           let row = table.insertRow(dataTable.rows.length - 1);

           let numberCell = row.insertCell();
           numberCell.append(document.createTextNode(currentData.length))

           let idCell = row.insertCell();          
           idCell.appendChild(document.createTextNode(item.id));

           let nameCell = row.insertCell();           
           nameCell.appendChild(document.createTextNode(item.fullName));

           let addressCell = row.insertCell();
           addressCell.appendChild(document.createTextNode(`${item.region}, ${item.city} ${item.streetAddress}`));

           let phoneCell = row.insertCell();
           phoneCell.appendChild(document.createTextNode(item.phoneNumber));
        });

        currentPage++;
    }

    handleInputChange = () => {
        document.getElementsByTagName("tbody")[0].innerHTML = "";
        currentPage = 1;
        currentData = [];
                
        getData();
    }

    textInput.oninput = (event) => {        
        if(Number.isInteger(Number(event.target.value))){            
            slider.value = event.target.value / 10;
        }
        else{
            slider.value = 0;
        }

        handleInputChange();
    }    

    regionSelect.onchange = () => {
        handleInputChange();
    }

    slider.onclick = (event) => {
        textInput.value = event.target.value * 10;
        handleInputChange();
    }

    textInput.oninput = () => { 
        handleInputChange();
    }

    seedInput.oninput = () => {
        handleInputChange();
    }
    
    randomSeed.onclick = () =>{
        seedInput.value = getRandomInt(100000);
        handleInputChange();
    }

    window.addEventListener('scroll', () => {
        if (window.innerHeight + document.documentElement.scrollTop !== document.documentElement.offsetHeight){
            return;
        }
        else{
            getData();
        }   
    });
}
