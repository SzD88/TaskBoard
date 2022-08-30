var idToTransfer;
var sortingAttributeMain = sortingAttributeFromHtml;
var ascendingMain = ascendintAttributeFromHtml;

window.addEventListener('load', async () => {

    const list_el = document.querySelector("#tasks");
    //  const selectOptions = document.querySelector("#select");


    try {
        await createSelectOptionList();
    } catch (e) {
        console.log("redirected");
    }
   // var projects_content_list = await getAllProjects(); 
 
   
    fillMainPage(sortingAttributeMain, ascendingMain)

});

