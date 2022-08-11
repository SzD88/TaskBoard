var idToTransfer;

window.addEventListener('load', () => {  
    
    const list_el = document.querySelector("#tasks");
 
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
                
                createList(singleObj, projectId, projectDescription, projectNumber);

            }
            return data;
        }).then(data => obj = data);
          
    function createList(inputData, inputData2, inputData3, inputData4) {

        const projectId = inputData2;
        const projectNumber = inputData4;  
        const projectTitle = inputData;   
        const projectDescription = inputData3;
        const task_el = document.createElement('div'); 
        task_el.classList.add('task');  
         
        const task_content_el = document.createElement('div');
 
        task_content_el.classList.add('content');  
        task_el.appendChild(task_content_el);

        // Element 1 
        const task_input_el4 = document.createElement('input');
        task_input_el4.classList.add('projectNumberHTML'); 
        task_input_el4.type = 'text';
        task_input_el4.value = projectNumber;
        task_input_el4.setAttribute('readonly', 'readonly');

        task_content_el.appendChild(task_input_el4);

        // Element 2
        const task_input_el = document.createElement('input');
        task_input_el.classList.add('text');  
        task_input_el.type = 'text';
        task_input_el.value = projectTitle;
        task_input_el.setAttribute('readonly', 'readonly');

        task_content_el.appendChild(task_input_el);

        // Element3 
        const task_input_el2 = document.createElement('input');
        task_input_el2.classList.add('text'); 
        task_input_el2.type = 'text';
        task_input_el2.value = projectId;
        task_input_el2.setAttribute('readonly', 'readonly');

        // Element 4
        const task_input_el3 = document.createElement('input');
        task_input_el3.classList.add('text'); 
        task_input_el3.type = 'text';
        task_input_el3.value = projectDescription;
        task_input_el3.setAttribute('readonly', 'readonly');

        task_content_el.appendChild(task_input_el3);



        const splited_text = document.createElement('div');
        splited_text.classList.add('text');  
        splited_text.type = 'text';
        splited_text.setAttribute('readonly', 'readonly');

        task_el.appendChild(splited_text);

         
        const task_actions_el = document.createElement('div');
        task_actions_el.classList.add('actions'); 
 
        const task_edit_el = document.createElement('button');
        task_edit_el.classList.add('edit');  
        task_edit_el.innerText = 'Edit';
         
        task_actions_el.appendChild(task_edit_el);
    
        task_el.appendChild(task_actions_el);
      
        try {
            list_el.appendChild(task_el);
        } catch (e) {
            console.log("redirected");
        } 
        task_edit_el.addEventListener('click', (e) => { / 
            if (task_edit_el.innerText.toLowerCase() == "edit") { 
                task_input_el.removeAttribute("readonly");  
                url = "/editproject.html?id=" + projectId;
                document.location.href = url;

            } else {
                task_edit_el.innerText = "Edit";
                task_input_el.setAttribute("readonly", "readonly");  
            }  
        });  

        //task_delete_el.addEventListener('click', (e) => {
        //    list_el.removeChild(task_el);
        //}); //odczytuje event nacisniecia button
    }



});

