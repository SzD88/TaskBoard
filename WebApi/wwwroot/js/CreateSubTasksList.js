// EditProject.html


//function funkcja1(id, upper div name/id/ - to append into it smt)
//{
//    new div

//    div.add id + content

//    if this div.subtasks != 0

//    foreach item in subtasks
//    funkcja1(id)


//    append child to item get on enter!
//}

// dostajesz 1 id - 
function createSubtaskList(singleSubTasksObject) { // it is almost prepered 

    const wholeBox = document.createElement('div'); // to ma byc div? 

    wholeBox.classList.add('singleSubTasksObject'); // nadaje id 

    // 1 dodaj jego content jako pole tekstowe - nadaj mu id 
    const wholeBox_input_element = document.createElement('input');
    wholeBox_input_element.setAttribute('value', singleSubTasksObject.content);
    wholeBox_input_element.setAttribute('id', singleSubTasksObject.id);
    wholeBox_input_element.type = 'text';

    wholeBox.appendChild(wholeBox_input_element);
     // nowy div ktory przechowa najpierw powyzszy input

    // ponizej ma dostac jeszcze wynik funkcji
    var allSubTasks = singleSubTasksObject.includedTasks;
    // foreach
    for (nextTask in allSubTasks) {
        // get data to append 
        var appendBelowLevels = createSubtaskList(allSubTasks[nextTask]); // wyslij go i przypisz do zmiennej
         
        wholeBox.appendChild(appendBelowLevels); // to nie do input tylko do div

    }
      // wholeBox.appendChild(appendBelowLevels); // to nie do input tylko do div


    return wholeBox;

}
//============
function createListOfSingleMainTask(itemToAppend) {

    const MainTasks = document.querySelector('#MainTasks');
   

    console.log(itemToAppend);
    MainTasks.appendChild(itemToAppend);
   
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



