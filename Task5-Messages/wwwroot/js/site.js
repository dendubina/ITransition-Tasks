{
    const baseUrl = "https://localhost:5001";
    const currentUserId = document.getElementById("currentUserId").value;
    const input = document.getElementById("receiverInput");
    const list = document.getElementById("list");
    const messagesHistory = document.getElementById("accordionExample");    

    input.onkeyup = async (event) => {

        list.innerHTML = "";

        let names = await getNames(event.target.value);

        names.forEach(elem => {

            let option = document.createElement("option");

            option.value = elem;

            list.appendChild(option);
        });
    }

    const getNames = async (substring) =>
    {
        let url = new URL("/Home/FindUsersBySubstring", baseUrl);
        url.searchParams.append("substring", substring);       

        let response = await fetch(url)
            .then(response => response.json());        

        return response;
    }
    
    const updateHistory = async (userId) =>{
        let url = new URL("/MessagesHistory/GetMessageHistoryBlock", baseUrl)
        url.searchParams.append("userId", userId);

        let response = await fetch(url)
            .then(response => response.text());

        messagesHistory.innerHTML = "";
        
        messagesHistory.innerHTML = response;
    }

    updateHistory(currentUserId);
    setInterval(() => updateHistory(currentUserId), 5000);
}