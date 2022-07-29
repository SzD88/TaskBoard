var idToTransfer;

window.addEventListener('load', () => { //on load :
    //przypisuje z HTML otagowanego jak niżej 
  //  const form = document.querySelector("#new-task-form");     // new task
    //Funkcja zwraca pierwszy element wewnątrz dokumentu, 
    // który pasuje do podanego selektora lub grupy selektorów.
    // selectors are used to target the HTML elements on our web pages


    //przypisuje z HTML otagowanego jak niżej
   // const input = document.querySelector("#new-task-input");
    //przypisuje z HTML otagowanego jak niżej 
    const list_el = document.querySelector("#tasks");


    // for now creating a container element can be used in html
    // const container = document.getElementById("container");
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
                let projectId = task_content_list[nextTask].id;
                let projectDescription = task_content_list[nextTask].description;
                let projectNumber = task_content_list[nextTask].projectNumber;
                list.push(task_content_list[nextTask]);
                createList(singleObj, projectId, projectDescription, projectNumber);

            }
            return data;
        }).then(data => obj = data)
        .then(() => console.log('')  //obj
        );

    function createList(inputData, inputData2, inputData3, inputData4) {

        const projectId = inputData2;
        const projectNumber = inputData4; // <-----
        const projectTitle = inputData; // <----- 
        const projectDescription = inputData3;
        // tworzy HTML Content Division element (<div>) jest rodzajem pojemnika na treść.
        const task_el = document.createElement('div'); // pewnie tutaj css dziala podobnie - a jednak nie...

        //dodaje do task_el to co jest wpisane w pole tekstowe
        task_el.classList.add('task'); // dobra rozumiem, jeżeli używasz task samo wtedy on go wpisuje jako 
        //treść ale nie pobiera wyglądu z CSS - a jak dasz 'task' wtedy to jest powiazane z css
        // w css to jest wpisane .task {....} 


        //kolejny kontener
        const task_content_el = document.createElement('div');

        //content... z html? content z task
        task_content_el.classList.add('content'); //class of contentc - odpowiada za wyglad
        //dodaje do task element pierwszy skladnik - content 
        task_el.appendChild(task_content_el);

        // Element 1 
        const task_input_el4 = document.createElement('input');
        task_input_el4.classList.add('projectNumberHTML'); // dodaje styl .text z css
        task_input_el4.type = 'text';
        task_input_el4.value = projectNumber;
        task_input_el4.setAttribute('readonly', 'readonly');

        task_content_el.appendChild(task_input_el4);

        // Element 2
        const task_input_el = document.createElement('input');
        task_input_el.classList.add('text'); // dodaje styl .text z css
        task_input_el.type = 'text';
        task_input_el.value = projectTitle;
        task_input_el.setAttribute('readonly', 'readonly');

        task_content_el.appendChild(task_input_el);

        // Element3 
        const task_input_el2 = document.createElement('input');
        task_input_el2.classList.add('text'); // dodaje styl .text z css
        task_input_el2.type = 'text';
        task_input_el2.value = projectId;
        task_input_el2.setAttribute('readonly', 'readonly');

        // Element 4
        const task_input_el3 = document.createElement('input');
        task_input_el3.classList.add('text'); // dodaje styl .text z css
        task_input_el3.type = 'text';
        task_input_el3.value = projectDescription;
        task_input_el3.setAttribute('readonly', 'readonly');

        task_content_el.appendChild(task_input_el3);



        //const splited_text = document.createElement('div');
        //splited_text.classList.add('text'); // dodaje styl .text z css
        //splited_text.type = 'text';
        //splited_text.setAttribute('readonly', 'readonly');

        //task_el.appendChild(splited_text);

         
        const task_actions_el = document.createElement('div');
        task_actions_el.classList.add('actions'); // dodaje styl
 
        const task_edit_el = document.createElement('button');
        task_edit_el.classList.add('edit'); // dodaje styl - klase edit w html w sumie ...
        task_edit_el.innerText = 'Edit';

        //const task_delete_el = document.createElement('button');
        //task_delete_el.classList.add('delete'); // dodaje styl
        //task_delete_el.innerText = 'Hide';

        task_actions_el.appendChild(task_edit_el);
      //  task_actions_el.appendChild(task_delete_el);
        //   task_actions_el.appendChild(task_new_el);

        //  const textnode = document.createTextNode("Water");

        task_el.appendChild(task_actions_el);
        //   task_el.appendChild(textnode);

        list_el.appendChild(task_el);

     // tutaj  // input.value = '';

        task_edit_el.addEventListener('click', (e) => { // dodajesz mu akcje w razie click
            if (task_edit_el.innerText.toLowerCase() == "edit") {
                //  task_edit_el.innerText = "Save";
                task_input_el.removeAttribute("readonly"); // tekst w polu zmienia na edytowalny
                // task_input_el.focus();  // tutaj jakby klika w niego - ustawia mu focus do wpisania wartosci 
                //  console.log(projectNumber);

                //  setVariables( projectNumber);
                //   functionWhenEditPressed(projectNumber)// bo on stad dalej wykonuje skrypt 
                //let redirectPage = () => {
                //    const url = "editprojects/" + projectNumber;
                //    window.location.href = url; }
                //----

                url = "/editproject.html?id=" + projectId;

                document.location.href = url;

            } else {
                task_edit_el.innerText = "Edit";
                task_input_el.setAttribute("readonly", "readonly"); // widocznie wpisywanie w te pole wartosci dziala w obie strony 
            } // on wychodzi i zostawia w tej formie - edit został zmieniony na save - czeka na wpisanie wartosciu w polu
            // ponowne klikniecie w save sprawdza czy jest edit - jezeli nie czyli save wtedy zmiena na edit i ustawia znowu na readonly
        }); //odczytuje event nacisniecia button

        //task_delete_el.addEventListener('click', (e) => {
        //    list_el.removeChild(task_el);
        //}); //odczytuje event nacisniecia button
    }



});

