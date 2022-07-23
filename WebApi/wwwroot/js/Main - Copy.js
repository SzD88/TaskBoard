// working example of other use of fetch async await 
console.log("test ouside then");
getText('api/Project');
///==============
async function getText(file) {
    let x = await fetch(file);
    let y = await x.text();
    console.log(y);
}
 
window.addEventListener('load', () => { //on load :
    //przypisuje z HTML otagowanego jak niżej 
    const form = document.querySelector("#new-task-form");
    //Funkcja zwraca pierwszy element wewnątrz dokumentu, 
    // który pasuje do podanego selektora lub grupy selektorów.
    // selectors are used to target the HTML elements on our web pages


    //przypisuje z HTML otagowanego jak niżej
    const input = document.querySelector("#new-task-input");
    //przypisuje z HTML otagowanego jak niżej 
    const list_el = document.querySelector("#tasks");

    const list_el2 = document.querySelector("#tasks2");

    // for now creating a container element can be used in html
    const container = document.getElementById("container");
    const list = [];
 
    fetch('api/Project')
        .then(response => {
            if (response.ok) {
                return response.json();
            } else {
                throw new Error(response.statusText);
            }
        })
        .then(data => {
            task_content_list = data;
            for (nextTask in task_content_list) {
                let singleObj = task_content_list[nextTask].title;
                let contentObject = task_content_list[nextTask].description;
                list.push(task_content_list[nextTask]);
                createList(singleObj + "  " + contentObject);
            }
        }); 
     
    form.addEventListener('submit', (e) => {
        e.preventDefault(); 
        const task = input.value;
        createList(task); 
    });
    // tutaj wszystko dzieje sie po załadowaniu strony lub kliknieciu submit
    // pamietaj że żeby kliknac submit musisz miec cos wpisane w pole wiec task/content != null

    function createList(inputData) {

        const task = inputData; // <-----
        // tworzy HTML Content Division element (<div>) jest rodzajem pojemnika na treść.
        const task_el = document.createElement('div'); // pewnie tutaj css dziala podobnie - a jednak nie...

        //dodaje do task_el to co jest wpisane w pole tekstowe
        task_el.classList.add('task'); // dobra rozumiem, jeżeli używasz task samo wtedy on go wpisuje jako 
        //treść ale nie pobiera wyglądu z CSS - a jak dasz 'task' wtedy to jest powiazane z css
        // w css to jest wpisane .task {....} 
         

        //kolejny kontener
        const task_content_el = document.createElement('div');

        //content... z html? content z task
        task_content_el.classList.add('content'); //class of contentc
        //dodaje do task element pierwszy skladnik - content 
        task_el.appendChild(task_content_el);

        //  wrap = "  ";

        //const task_wrap_el = document.createElement('div');
        //task_wrap_el.classList.add(wrap)

        //task_el.appendChild(task_wrap_el);

        // to dodaje do samej belki projekt/descr
        const task_input_el = document.createElement('input');
        task_input_el.classList.add('text'); // dodaje styl .text z css
        task_input_el.type = 'text';
        task_input_el.value = task;
        task_input_el.setAttribute('readonly', 'readonly');

        task_content_el.appendChild(task_input_el);


        ///==
        const splited_text = document.createElement('div');

        ///===
        const task_actions_el = document.createElement('div');
        task_actions_el.classList.add('actions'); // dodaje styl

        //const task_new_el = document.createElement('button');
        //task_new_el.classList.add('zz2'); // dodaje styl
        //task_new_el.innerText = 'zzz';

        const task_edit_el = document.createElement('button');
        task_edit_el.classList.add('edit'); // dodaje styl
        task_edit_el.innerText = 'Edit';

        const task_delete_el = document.createElement('button');
        task_delete_el.classList.add('delete'); // dodaje styl
        task_delete_el.innerText = 'Delete';

        task_actions_el.appendChild(task_edit_el);
        task_actions_el.appendChild(task_delete_el);
      //   task_actions_el.appendChild(task_new_el);

      //  const textnode = document.createTextNode("Water");

        task_el.appendChild(task_actions_el);
      //   task_el.appendChild(textnode);

        list_el.appendChild(task_el);


       // task_el.appendChild(task_content_el); 
       //  list_el.appendChild("adsd");

        input.value = '';

        task_edit_el.addEventListener('click', (e) => {
            if (task_edit_el.innerText.toLowerCase() == "edit") {
                task_edit_el.innerText = "Save";
                task_input_el.removeAttribute("readonly");
                task_input_el.focus();
            } else {
                task_edit_el.innerText = "Edit";
                task_input_el.setAttribute("readonly", "readonly");
            }
        }); //odczytuje event nacisniecia button

        task_delete_el.addEventListener('click', (e) => {
            list_el.removeChild(task_el);
        }); //odczytuje event nacisniecia button
    }


   
});
