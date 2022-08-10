var projectId;
let idToUse;
let titleToUse;
let descriptionToUse;
let projNumberToUse;

window.onload = function () {
    try {
        var url = document.location.href,
            params = url.split('?')[1].split('&'),
            data = {}, tmp;
        for (var i = 0, l = params.length; i < l; i++) {
            tmp = params[i].split('=');
            data[tmp[0]] = tmp[1];
        }
        projectId = data.id;
        InputDataToForm("/api/Project/" + projectId);

    } catch (e) {
        "Main Page"
    }
}

async function InputDataToForm(pathToGetById) {
    let x = await fetch(pathToGetById);
    let y = await x.json();

    idToUse = y.id;
    titleToUse = y.title;
    descriptionToUse = y.description;
    projectNumberToUse = y.projectNumber;

    // ---- adding variables
    inputValuesToForm(idToUse, projectNumberToUse, titleToUse, descriptionToUse);

    var listOfSubtasks = y.mainTasks;

    const allMainTasksToDisplay = document.createElement('div');


    allMainTasksToDisplay.classList.add('allMainTasksToDisplay');

    for (nextTask in listOfSubtasks) {
        //console.log("every specyfic subtask of above list: ");
        //console.log(listOfSubtasks[nextTask]);
        // wysyla kazdy z main taskow do kolejnego pliku js - chce stworzyc nowy pełny subtask

        var idToSend = idToUse;
        var itemToAppend = await createSubtaskList(listOfSubtasks[nextTask], idToSend);

        //  await createListOfSingleMainTask(itemToAppend);
        console.log("item to append : ");
        console.log(itemToAppend);

        allMainTasksToDisplay.appendChild(itemToAppend);
    }


    // tu trzeba stworzyc div i do neigo dodawac kolejne powyzsze stworzone listy, bo to sa listy main taskow a tak tylko 1 pokazuje sie 
    await createListOfSingleMainTask(allMainTasksToDisplay);
}

function replaceFormValuesToInputed() //changes all fields to filled //or dont change if no changes
{
    var idFromUpdatedForm = changeAttributeByName("projectId"); // html names/id
    var projectNumberFromUpdatedForm = changeAttributeByName("projectNumber");// html names/id  
    var titleFromUpdatedForm = changeAttributeByName("title");// html names/id
    var descriptionFromUpdatedForm = changeAttributeByName("description");// html names/id
    console.log(projectNumberFromUpdatedForm);

    putDataFromFieldsToDatabase(idFromUpdatedForm, projectNumberFromUpdatedForm, titleFromUpdatedForm, descriptionFromUpdatedForm);
}

async function putDataFromFieldsToDatabase(projecId, projectNumber, title, description) {

    var projJson = createJSON(title, description, projectNumber); //works

    var url = "/api/Project";

    try {
        const config = {
            method: 'PUT',
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json',
            },
            body: projJson // JSON.stringify(data)
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

function createJSON(title, description, projectNumberToUse) {
    var projectJSON = {
        "id": idToUse,
        "projectNumber": projectNumberToUse,
        "title": title,
        "description": description,
        "completed": false //        change it later !!
    }
    const projJsonString = JSON.stringify(projectJSON);
    return projJsonString;
};

function changeAttributeByName(attributeName) {
    var getAtribute = document.getElementById(attributeName);
    var attributeChanged = getAtribute.value.replace();
    getAtribute.value = attributeChanged;

    return getAtribute.value;
}

function inputValuesToForm(idToUse, projectNumber, titleToUse, descriptionToUse) {
    document.getElementById('projectId').setAttribute('value', idToUse);
    document.getElementById('projectNumber').setAttribute('value', projectNumber);
    document.getElementById('title').setAttribute('value', titleToUse);
    document.getElementById('description').setAttribute('value', descriptionToUse);
    //override variables

    document.getElementById('projectNumber').getAttribute("value"); // var idToUse = 
    document.getElementById('title').getAttribute("value");//var titleToUse = 
    document.getElementById('description').getAttribute("value");// var   var descriptionToUse = 


}


async function createMainTask(content) {

    console.log(idToUse, content);
    await createSubTaskBasedOnAboveId(idToUse, content);
    url = "/editproject.html?id=" + projectId;
    document.location.href = url;
}
//async function setDomButtons() {

//    var element = document.getElementById("createMainTaskInputValue");
//    element.onkeypress = async function (e) {
//        if (e.keyCode == 13) {
//            createMainTask(element.value)
//        }
//    }
//}