{
    const changeAllCheckBox = document.getElementById("selectAll");

    changeAllCheckBox.onclick = () => {
        document.querySelectorAll(".user-check-box").forEach((item) => {
            item.checked = changeAllCheckBox.checked;
        });
    }
}