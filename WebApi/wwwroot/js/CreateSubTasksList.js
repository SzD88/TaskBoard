

const list_el = document.querySelector("#subTasks"); //subTasks
 

 

// stworz obiekt - dodaj do niego liste obiektow  - wywolaj funkcje w fetch z edit projetk!!!!

// czy ja nie chce tu teraz miec retrive all included tasks ale mam takie cos zawarte juz w project
//moze zrob funkcję która sprawdza czy są kolejne subtaski w subtasku , w subtasku itd itd...

// mam liste id subtasków - > wykonuje foreach - dla kazdego pobieram z db - content subtasku i jego id 


//tutaj chce przekazac content i liste subtaskow - a w sumie ich contentu


// foreach 

// cała ta funkcja musi byc jakos sprytnie zapętlona żeby wykonać każdy subtask  z kazdego subtasku

function createSubtaskList( subTasksObjects ) {
     
    var list1 = [];

    for (nextTask in subTasksObjects) {
        list1.push(subTasksObjects[nextTask]);
    }

    console.log(list1);

    /// tu sie zaczyna tworzenie listy 

    const task_el = document.createElement('div');

    task_el.classList.add('subTask');


     
    const task_content_el = document.createElement('div');

     
    task_content_el.classList.add('content');  // can be changed

    task_el.appendChild(task_content_el);

    // Tu chce dodac moj slodki plusik a potem pole tekstowe do create subtask
    const task_input_el1 = document.createElement('button');
    task_input_el1.classList.add('addSubTask');
    task_input_el1.type = 'button';
    task_input_el1.setAttribute('readonly', 'readonly');
  //  task_content_el.appendChild(task_input_el1); // do tego mozesz zrobic append child i dodac podtaski

    const task_input_elNewTask = document.createElement('input');
    task_input_elNewTask.classList.add('newSubTask');
    task_input_elNewTask.type = 'text';
  //  task_content_el.appendChild(task_input_elNewTask); // do tego mozesz zrobic append child i dodac podtaski

    const addButtonAndNewSubTaskInLine = document.createElement('div');
    addButtonAndNewSubTaskInLine.appendChild(task_input_el1);
    addButtonAndNewSubTaskInLine.appendChild(task_input_elNewTask);
    addButtonAndNewSubTaskInLine.style.display = "flex";
    task_content_el.appendChild(addButtonAndNewSubTaskInLine); // do tego mozesz zrobic append child i dodac podtaski

    // Element 1
    const task_input_el2 =  document.createElement('div');
    task_input_el2.classList.add('subTaskContent');
        //document.createElement('output');
    //task_input_el2.classList.add('subTask');
    //task_input_el2.type = 'text';
    //task_input_el2.setAttribute('readonly', 'readonly');

    
    task_content_el.appendChild(task_input_el2); // do tego mozesz zrobic append child i dodac podtaski

    const task_input_level3 = document.createElement('output');
    task_input_level3.classList.add('subTask'); 
    task_input_level3.type = 'text';
    task_input_level3.setAttribute('readonly', 'readonly');

    task_input_el2.appendChild(task_input_level3);

    for (nextTask in list1) {

        console.log(nextTask);
        var temp = document.createElement('input');
        // var text = document.createTextNode(list1[nextTask].content); // this is wrong way 
        var text  =  list1[nextTask].content;
        temp.value = text;
    //    let li = document.createElement('li');
    //    li.textContent = text ;
         
    //    console.log(li.textContent);
       task_input_level3.appendChild(temp);

        //albo mozesz po prostu przewidziec maksymalna liczbe poziomow 
    }


    const textnode = document.createTextNode("+");
    task_input_el1.appendChild(textnode);
      
    list_el.appendChild(task_el);


     
    task_input_el1.addEventListener('click', (e) => {
         
       // let contentToPost = document.querySelector('.newSubTask').value;  // both work  fine 
        let contentToPost = task_input_elNewTask.value;   // both work fine
        task_input_elNewTask.value = '';

        let levelAboveId = projectId;// i want here to have id of container above or if it is first then
            // project id 

         createSubTaskBasedOnAboveId(levelAboveId,contentToPost)
        console.log(levelAboveId);
        
    });
}
async function createSubTaskBasedOnAboveId(levelAboveId, content ) {


    var subTaskJSON = createSubTaskJSON(levelAboveId, content ); //works

    var url = "/api/SubTask";

    try {
        const config = {
            method: 'POST',
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json',
            },
            body: subTaskJSON // JSON.stringify(data)
        }
        const response = await fetch(url, config);
        //const json = await response.json()
        if (response.ok) {
            //return json
            console.log(response);
            return response
        } else {
            //
        }
    } catch (error) {
        //
    }
}

function createSubTaskJSON(levelAboveId, content)
{ 
    var subTaskJSON =  
    {
        "content": content,
        "levelAboveId": levelAboveId
    }
    const subTaskString = JSON.stringify(subTaskJSON);
     return subTaskString; 
}



