var idToTransfer;
var sortingAttributeMain = sortingAttributeFromHtml;
var ascendingMain = ascendintAttributeFromHtml;

window.addEventListener('load', async () => {


    //przypisuje z HTML otagowanego jak niżej
   // const input = document.querySelector("#new-task-input");
    //przypisuje z HTML otagowanego jak niżej 
    const list_el = document.querySelector("#tasks");


    try {
        await createSelectOptionList();
    } catch (e) {
        console.log("redirected");
    }
   // var projects_content_list = await getAllProjects(); 
 
   
    fillMainPage(sortingAttributeMain, ascendingMain)

});

