var startPosition = 320; // distance from the left of first subtask on list

async function createSubtaskList(singleSubTasksObject, levelAboveId) {

    const wholeBox = document.createElement('div'); // du

    wholeBox.classList.add('singleSubTasksObject');

    const list_object = document.createElement("li");
    list_object.classList.add('singleListObject');

    const wholeBox_input_element = document.createElement('input');
    wholeBox_input_element.setAttribute('id', singleSubTasksObject.id);

    wholeBox_input_element.setAttribute('value', singleSubTasksObject.content); // + " /above:/ " + singleSubTasksObject.levelAboveId + " /its id:/ " + singleSubTasksObject.id

    wholeBox_input_element.type = 'text';

    wholeBox_input_element.addEventListener("focus", () => {
        console.log("you clicked input box");

        wholeBox_input_element.onkeypress = async function (e) {
            if (e.keyCode == 13) {

                // take this input data
                var idToFetch = wholeBox_input_element.id;
                var dataToFetch = wholeBox_input_element.value;
                var completedToFetch = false;
                var levelAboveIdToFetch = levelAboveId; //singlesubtask.id
                // tutaja nadajesz level above i dlatego go nie zaciaga
                // natomiast ten level above moze byc albo id projektu albo subtasku i dlatego to nie dziala


                var subTaskJson = createSubTaskJSONToPut(idToFetch, dataToFetch, completedToFetch, levelAboveIdToFetch);


                // fetch 
                var url = "/api/SubTask"

                putSubTaskMethod(subTaskJson, url);

            }
        }
    })

    wholeBox.appendChild(wholeBox_input_element);
    // dodatno opis

    var addButtonObjectEarlier = await addButton(singleSubTasksObject.id);
    wholeBox.appendChild(addButtonObjectEarlier); // #blad

    // if (singleSubTasksObject.includedTasks.length > 0) {

    var allSubTasks = singleSubTasksObject.includedTasks; // probuje pobrac to , bo juz kolejny nie ma zawartych taskow #uwaga 


    for (num in allSubTasks) {
        var currentTaskOfIncluded = allSubTasks[num];
        var idOfCurrentTask = allSubTasks[num].id;

        if (currentTaskOfIncluded !== "undefined") {

            var levelAboveToSend = singleSubTasksObject.id;
            var appendBelowLevels = await createSubtaskList(currentTaskOfIncluded);

            // wholeBox.appendChild(addButtonObject); // #blad tu byl najpowazniejszy blaaaaaaad #uwaga 

            list_object.appendChild(appendBelowLevels);
            //  wholeBox.appendChild(appendBelowLevels);  

            //background colour inherit 

            //startPosition = startPosition - 20;// tutaj
            //var zmiennaString = startPosition.toString() + "px";
            //console.log(zmiennaString + "this is indent of " + currentTaskOfIncluded.content);
            // wholeBox.style.textIndent = zmiennaString;

            wholeBox.appendChild(list_object);
        }
    }


    return wholeBox;

}

function doIndent() {

}


async function createListOfSingleMainTask(itemToAppend) {
    const MainTasks = document.querySelector('#MainTasks');
    //   console.log(itemToAppend);
    MainTasks.appendChild(itemToAppend);
}//


async function addButton(aboveId) {

    const divWithButton = document.createElement('div');
    divWithButton.classList.add('buttonBox');

    //const addSubTaskOfCurrentLevel = document.createElement('button');
    //addSubTaskOfCurrentLevel.classList.add('addSubTask');
    //addSubTaskOfCurrentLevel.type = 'button';
    //addSubTaskOfCurrentLevel.setAttribute('readonly', 'readonly');
    //const addNode = document.createTextNode("+");
    //addSubTaskOfCurrentLevel.appendChild(addNode);

    const newTaskInput = document.createElement('input');
    newTaskInput.classList.add('addSubTaskInput'); // ten nie ma wciec 
    newTaskInput.addEventListener("focus", () => {
        // clearing the input field value
        console.log("above id after click = " + aboveId);
        newTaskInput.value = "";


    })
    newTaskInput.style.background = "white";

    newTaskInput.type = 'text';
    newTaskInput.value = '+';
    newTaskInput.onkeypress = async function (e) {
        if (e.keyCode == 13) {


            var cont = newTaskInput.value;
            var gettenId = await createSubTaskBasedOnAboveId(aboveId, cont);

            newTaskInput.setAttribute('id', gettenId);

            url = "/editproject.html?id=" + projectId;
            document.location.href = url;

        }
    }

    divWithButton.appendChild(newTaskInput);



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

        if (response.status === 201) {  // response.status === 200 (response.ok)
            //return json
            const json = await response.json();
            //  console.log(json + "   to response po created ");
            //  var cos = json.stringify();
            console.log(json + " z wnetrza response");
            return json;
        } else {
            console.log("KOD  response inny niz 201");
        }
    } catch (error) {
        //
    }

    ////
    //const response = await fetch(url, config);
    //if (response.ok) {
    //    console.log(response);
    //    return response
    //} else {

    //}
    ///
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



function createSubTaskJSONToPut(id, content, completed, levelAboveId) {
    var subTaskJSON = {
        "id": id,
        "content": content,
        "completed": completed,
        "levelAboveId": levelAboveId
    }
    const subTaskJSONString = JSON.stringify(subTaskJSON);
    return subTaskJSONString;
};


async function putSubTaskMethod(jsonToPut, url) {

    try {
        const config = {
            method: 'PUT',
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json',
            },
            body: jsonToPut // JSON.stringify(data)
        }
        const response = await fetch(url, config);
        if (response.ok) {
            console.log(response);
            return response
        } else {

        }
    } catch (error) {

    }

}