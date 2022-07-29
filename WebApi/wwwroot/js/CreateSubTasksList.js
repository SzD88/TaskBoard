

const list_el = document.querySelector("#subTasks"); //subTasks
 

 

// stworz obiekt - dodaj do niego liste obiektow  - wywolaj funkcje w fetch z edit projetk!!!!

// czy ja nie chce tu teraz miec retrive all included tasks ale mam takie cos zawarte juz w project
//moze zrob funkcję która sprawdza czy są kolejne subtaski w subtasku , w subtasku itd itd...

// mam liste id subtasków - > wykonuje foreach - dla kazdego pobieram z db - content subtasku i jego id 


//tutaj chce przekazac content i liste subtaskow - a w sumie ich contentu


// foreach 

// cała ta funkcja musi byc jakos sprytnie zapętlona żeby wykonać każdy subtask  z kazdego subtasku

function createSubtaskList(  subTasksObjects ) {
     
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
    const task_input_el2 = document.createElement('output');
    task_input_el2.classList.add('subTask');
    task_input_el2.type = 'text';
    task_input_el2.value = "qwa nie wiem 2";
    task_input_el2.setAttribute('readonly', 'readonly');

    task_content_el.appendChild(task_input_el2); // do tego mozesz zrobic append child i dodac podtaski

    const task_input_level2 = document.createElement('output');
    task_input_level2.classList.add('subTask');
    task_input_level2.type = 'text';
    task_input_level2.value = "jakies gowno";
    task_input_level2.setAttribute('readonly', 'readonly');

    task_content_el.appendChild(task_input_level2);

    const textnode = document.createTextNode("+");
    task_input_el1.appendChild(textnode);
      
    list_el.appendChild(task_el);



   
    return console.log("ok");

}





