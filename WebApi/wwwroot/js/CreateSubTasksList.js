var startPosition = 80; // distance from the left of first subtask on list

function createSubtaskList(singleSubTasksObject) {

    const wholeBox = document.createElement('div');

    wholeBox.classList.add('singleSubTasksObject');


    const wholeBox_input_element = document.createElement('input');
    wholeBox_input_element.setAttribute('value', singleSubTasksObject.content);
    wholeBox_input_element.setAttribute('id', singleSubTasksObject.id);
    wholeBox_input_element.type = 'text';

    wholeBox.appendChild(wholeBox_input_element);

    var allSubTasks = singleSubTasksObject.includedTasks;

    for (nextTask in allSubTasks) {


        var appendBelowLevels = createSubtaskList(allSubTasks[nextTask]);

        var addButtonObject = addButton(allSubTasks[nextTask].id);

        wholeBox.appendChild(addButtonObject);
        wholeBox.appendChild(appendBelowLevels);
    }
    startPosition = startPosition - 20 // tutaj
    var zmiennaString = startPosition.toString() + "px";
    wholeBox.style.textIndent = zmiennaString;
    return wholeBox;
}


function createListOfSingleMainTask(itemToAppend) {
    const MainTasks = document.querySelector('#MainTasks');
    console.log(itemToAppend);
    MainTasks.appendChild(itemToAppend);
}//


function addButton(aboveId) {

    const divWithButton = document.createElement('div');
    divWithButton.classList.add('buttonBox');

    const addSubTaskOfCurrentLevel = document.createElement('button');
    addSubTaskOfCurrentLevel.classList.add('addSubTask');
    addSubTaskOfCurrentLevel.type = 'button';
    addSubTaskOfCurrentLevel.setAttribute('readonly', 'readonly');
    const addNode = document.createTextNode("+");
    addSubTaskOfCurrentLevel.appendChild(addNode);

    const newTaskInput = document.createElement('input');
    newTaskInput.classList.add('addSubTaskInput'); // ten nie ma wciec 
    newTaskInput.setAttribute('value', '');
    newTaskInput.setAttribute('id', aboveId);
    newTaskInput.type = 'text';
     
   //  divWithButton.style.textIndent = "130px";

    divWithButton.appendChild(newTaskInput);

    divWithButton.appendChild(addSubTaskOfCurrentLevel);


    return divWithButton;
}
// ========================
async function createSubTaskBasedOnAboveId(levelAboveId, content) {


    var subTaskJSON = createSubTaskJSON(levelAboveId, content); //works

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

function createSubTaskJSON(levelAboveId, content) {
    var subTaskJSON =
    {
        "content": content,
        "levelAboveId": levelAboveId
    }
    const subTaskString = JSON.stringify(subTaskJSON);
    return subTaskString;
}



