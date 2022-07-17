﻿window.addEventListener('load', () => {
    const form = document.querySelector("#new-task-form");
    const input = document.querySelector("#new-task-input");
    const list_el = document.querySelector("#tasks");

    // for now creating a container element can be used in html
    const container = document.getElementById("container");
    const list = [];

    
    fetch('api/SubTask')
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
                let singleObj = task_content_list[nextTask].content;
                list.push(task_content_list[nextTask]);
                createList(singleObj);
            }
        });


    async function foo()
    {
        let obj;

        const res = await fetch('api/SubTask')

        obj = await res.json();

       // console.log(obj[1])
        return obj;
    }

    var gowno = foo();

    console.log(gowno);

    //chce miec liste objektow pobranych z api w js

    // chce moc odnalezc po id dany obiekt

    // przypisuje obecnie do listy wyswietlanej obiekty ale sztywno jako content i koniec

    // musze powiazac id z contentem i ten element przekazywac do listy+


    form.addEventListener('submit', (e) => {
        e.preventDefault();

        const task = input.value;
        createList(task);


    });

    function createList(inputData) {

        const task = inputData;

        const task_el = document.createElement('div');
        task_el.classList.add('task');

        const task_content_el = document.createElement('div');
        task_content_el.classList.add('content');

        task_el.appendChild(task_content_el);

        const task_input_el = document.createElement('input');
        task_input_el.classList.add('text');
        task_input_el.type = 'text';
        task_input_el.value = task;
        task_input_el.setAttribute('readonly', 'readonly');

        task_content_el.appendChild(task_input_el);

        const task_actions_el = document.createElement('div');
        task_actions_el.classList.add('actions');

        const task_edit_el = document.createElement('button');
        task_edit_el.classList.add('edit');
        task_edit_el.innerText = 'Edit';

        const task_delete_el = document.createElement('button');
        task_delete_el.classList.add('delete');
        task_delete_el.innerText = 'Delete';

        task_actions_el.appendChild(task_edit_el);
        task_actions_el.appendChild(task_delete_el);

        task_el.appendChild(task_actions_el);

        list_el.appendChild(task_el);

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
