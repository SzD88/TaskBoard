var idToTransfer;
var sortingAttributeMain = sortingAttributeFromHtml;
var ascendingMain = ascendingAttributeFromHtml;

window.addEventListener('load', () => { //on load :
    //przypisuje z HTML otagowanego jak niżej 
  //  const form = document.querySelector("#new-task-form");     // new task
    //Funkcja zwraca pierwszy element wewnątrz dokumentu, 
    // który pasuje do podanego selektora lub grupy selektorów.
    // selectors are used to target the HTML elements on our web pages

   
    //  const selectOptions = document.querySelector("#select");


    // for now creating a container element can be used in html
    // const container = document.getElementById("container");
    const list = [];

    fillMainPage(sortingAttributeMain, ascendingMain);
   
     

});

