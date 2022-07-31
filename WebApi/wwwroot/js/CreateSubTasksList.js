 const list_el = document.querySelector("#subTasks"); // EditProject.html
 
function createSubtaskList( subTasksObjects ) { // it is almost prepered 
     
    var list1 = [];  // czym jest ta lista ? 
   //   console.log( list1);

    for (nextTask in subTasksObjects) {
        list1.push(subTasksObjects[nextTask]); // temporary
    }

   // console.log(list1); // list of subtasks JSON with all 4 properties 
     
    const task_el = document.createElement('div');

    task_el.classList.add('subTask');
     
    const task_content_el = document.createElement('div');
     
    task_content_el.classList.add('content');  // should be changed

    task_el.appendChild(task_content_el);

   // First elements - I want to loop this from here:

    const task_input_el1 = document.createElement('button');
    task_input_el1.classList.add('addSubTask');
    task_input_el1.type = 'button';
    task_input_el1.setAttribute('readonly', 'readonly');

    const task_input_elNewTask = document.createElement('input');
    task_input_elNewTask.classList.add('newSubTask');
    task_input_elNewTask.type = 'text';
  //  task_content_el.appendChild(task_input_elNewTask); // do tego mozesz zrobic append child i dodac podtaski

    //Whole line with + button and text field and post command 
    const addButtonAndNewSubTaskInLine = document.createElement('div');
    addButtonAndNewSubTaskInLine.appendChild(task_input_el1);
    addButtonAndNewSubTaskInLine.appendChild(task_input_elNewTask);
    addButtonAndNewSubTaskInLine.style.display = "flex";
    task_content_el.appendChild(addButtonAndNewSubTaskInLine); // do tego mozesz zrobic append child i dodac podtaski

    //====== end

    // Element 1
    const task_input_el2 =  document.createElement('div');
    task_input_el2.classList.add('mainSubTasks');
      
    task_content_el.appendChild(task_input_el2);  

    const task_input_level3 = document.createElement('div');
    task_input_level3.classList.add('subTaskContent');
     

    task_input_el2.appendChild(task_input_level3);
    // ===================================================================================================
    for (nextTask in list1) {

      //  console.log(nextTask);
      //  var temp = document.createElement('input');
        var temp = document.createElement('div');

       // temp = document.classList.add(temp.id);
        // var text = document.createTextNode(list1[nextTask].content); // this is wrong way 
        var text  =  list1[nextTask].content;
        temp.innerHTML = text;

        var singleSubTask = list1[nextTask];   // wypisuje pojedynczy json  -A-

        loopOfprint(singleSubTask);

        function loopOfprint(input1) {
              console.log(input1);

            var numberOfTimes = input1.includedTasks.length;  // licznosc podtasku 
             console.log(numberOfTimes);
            for (var i = 0; i < numberOfTimes; i++) {
                /* for (singleTask in singleSubTask.includedTasks) {*/
                var tempId = input1.includedTasks[i];
                console.log(i);
                 loopOfprint(tempId);
            }
        }

       // temp.value = text;
    //    let li = document.createElement('li');
    //    li.textContent = text ;
         
    //    console.log(li.textContent);

        //postawic jakiegos ifa... ? 
     
        var thisSpecifiedSubTask = list1[nextTask];
         
        

        var numberOfIncludedSubTasks = thisSpecifiedSubTask.includedTasks.length; // returning 0 so great
        for (var i = 0; i < numberOfIncludedSubTasks; i++) {
          //  console.log(thisSpecifiedSubTask.includedTasks[i]);
           // console.log(thisSpecifiedSubTask);

        }
       // createSubtaskList(list1);


          /// divy z textem wyrzuca  
      //  console.log(list1);
       task_input_level3.appendChild(temp);
        }
        //albo mozesz po prostu przewidziec maksymalna liczbe poziomow 
     


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
       // console.log(levelAboveId);
        
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



