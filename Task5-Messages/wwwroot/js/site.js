{
    const baseUrl = "https://localhost:5001";
    const currentUserId = document.getElementById("currentUserId").value;
    const input = document.getElementById("receiverInput");
    const list = document.getElementById("list");
    const messagesHistory = document.getElementById("accordionExample");
    let currentMessagesCount = 0;    

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
    
    const getUserMessages = async (userId) =>{
        let url = new URL("/MessagesHistory/Messages", baseUrl)
        url.searchParams.append("userId", userId);        

        let response = await fetch(url)
            .then(response => response.json());

        return response;
    }

    const updateHistory = async () =>{        
        let messages = await getUserMessages(currentUserId);

        await updateMessagesBlock(messages);        
    }

    const updateMessagesBlock = async (messages) => {
        let url = new URL("/MessagesHistory/MessageBlock", baseUrl);    
        let currentArrlength = messages.length;        

        messages.splice(0, currentMessagesCount);

        for (let i = 0; i < messages.length; i++){
            let formData = new FormData();
            formData.append('Id', messages[i].id);
            formData.append('Date', messages[i].date);
            formData.append('SenderName', messages[i].author.name);
            formData.append('Title', messages[i].subject);
            formData.append('Text', messages[i].text)

            let response = await fetch(url, {
                body: formData,
                method: "post"
            }).then(response => response.text());            

            messagesHistory.insertAdjacentHTML('afterBegin', response);         
        }
        currentMessagesCount = currentArrlength;    
    }

    updateHistory(currentUserId);
    setInterval(() => updateHistory(currentUserId), 5000);
}