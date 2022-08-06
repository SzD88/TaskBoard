var startPosition = 280; // distance from the left of first subtask on list

async function createSubtaskList(singleSubTasksObject) { //// tu masz błąd na bank

    const wholeBox = document.createElement('div');

    wholeBox.classList.add('singleSubTasksObject');


    const wholeBox_input_element = document.createElement('input');  // wpisujesz w input obsługiwany single task 
    wholeBox_input_element.setAttribute('id', singleSubTasksObject.id); // to jest blad, bo ty nie masz mu ustawiac id above tylko nowe #blad #bug
    wholeBox_input_element.setAttribute('value', singleSubTasksObject.content + "- content /  above id: " + singleSubTasksObject.aboveId + " and its id:" + singleSubTasksObject.id);

    wholeBox_input_element.type = 'text';

    wholeBox.appendChild(wholeBox_input_element);

    // wszystkie zawarte subtaski w obsługiwanym subtasku
    if (singleSubTasksObject.includedTasks.length > 0) {


        var allSubTasks = singleSubTasksObject.includedTasks; // probuje pobrac to , bo juz kolejny nie ma zawartych taskow #uwaga 

        console.log("all subtasks - before next foreach looop");
        console.log(allSubTasks);


        /*try {*/
        for (num in allSubTasks) { // w ktoryms momencie sie robi undefined #blad ktyryczny 
            // mozesz tu dac if #sugestia

            var currentTask = allSubTasks[num];
            var idOfCurrentTask = allSubTasks[num].id;

            if (currentTask === "undefined") {
                return wholeBox;
            }
            if (currentTask !== "undefined") {


                console.log("from second script: id of current task");
                console.log(idOfCurrentTask);
                console.log(num + " attempt " + " of all sum of attempts possible : " + allSubTasks.length);
                //  debugger;

                //#solve - tutaj cos jest nie tak, nie dopisuje above id takiego jakie ja chce cos zle przekazuje do funkcji, moze napisac ja od nowa

                var appendBelowLevels = await createSubtaskList(allSubTasks[num]); // to wywoluje blad !! #blad krytyczny
                //  debugger;
             //   console.log(allSubTasks[num].id + " to sa id kolejnych podtaskow poza glownym a ich tresc to  " + allSubTasks[num].content);
                // to bugowalo no lol
                var addButtonObject = await addButton(allSubTasks[nextTask].id);

                wholeBox.appendChild(addButtonObject); // #blad
                wholeBox.appendChild(appendBelowLevels); // #blad - czy one bedac tutaj appendowane nie moga zostac przeskoczone ? 




                startPosition = startPosition - 20;// tutaj
                var zmiennaString = startPosition.toString() + "px";
                wholeBox.style.textIndent = zmiennaString;

            }
         
        }
    }
    

    return wholeBox;

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
    // newTaskInput.setAttribute('value', aboveId);  //'+'
    newTaskInput.addEventListener("focus", () => {
        // clearing the input field value
        newTaskInput.value = "";
    })
    // newTaskInput.setAttribute('id', aboveId); /// to chce zrobic ? 

    newTaskInput.type = 'text';
    newTaskInput.onkeypress = async function (e) {
        if (e.keyCode == 13) {


               var cont = newTaskInput.value;
            //  // tu bym chcial fetch i nic wiecej i przeladowac strone
                var gettenId = await createSubTaskBasedOnAboveId(aboveId, cont);
            // // tu opwinienem dostac id i te id przypisac do nowego obiektu
            console.log(gettenId + " po wykonaniu fetch");
            //  // ktory przekaze do newTaskInput.id


               newTaskInput.setAttribute('id', gettenId);  // getten should be

            //  // i musisz z fetcha uzyskac id i bedzie z górki 
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



