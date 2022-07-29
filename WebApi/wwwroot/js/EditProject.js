var projectId;
let idToUse;
let titleToUse;
let descriptionToUse;
let projNumberToUse;

window.onload = function () {
    // splits url to get id transfered from main.js
    var url = document.location.href,
        params = url.split('?')[1].split('&'),
        data = {}, tmp;
    for (var i = 0, l = params.length; i < l; i++) {
        tmp = params[i].split('=');
        data[tmp[0]] = tmp[1];
    }


    projectId = data.id;

    InputDataToForm("/api/Project/" + projectId);
}

async function InputDataToForm(pathToGetById) {
    let x = await fetch(pathToGetById);
    let y = await x.json();
    // console.log(y);  // returns json of 1 acurate project

   // console.log(y);
    //redirect to editProjecthtml
    idToUse = y.id;
    titleToUse = y.title;
    descriptionToUse = y.description;
    projectNumberToUse = y.projectNumber;

    // ---- adding variables
    inputValuesToForm(idToUse, projectNumberToUse, titleToUse, descriptionToUse);
}

// it is the function on click "Zatwierdz zmiany"
function replaceFormValuesToInputed() //changes all fields to filled //or dont change if no changes
{
    var idFromUpdatedForm = changeAttributeByName("projectId"); // html names/id
    var projectNumberFromUpdatedForm = changeAttributeByName("projectNumber");// html names/id // null - nie przypisane !
    var titleFromUpdatedForm = changeAttributeByName("title");// html names/id
    var descriptionFromUpdatedForm = changeAttributeByName("description");// html names/id
    console.log(projectNumberFromUpdatedForm);

    putDataFromFieldsToDatabase(idFromUpdatedForm, projectNumberFromUpdatedForm , titleFromUpdatedForm, descriptionFromUpdatedForm);
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

function createJSON(title, description,  projectNumberToUse) {
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
    var getAtribute = document
        .getElementById(attributeName);
    var attributeChanged = getAtribute.value.replace();
    getAtribute.value = attributeChanged;

    // console.log("from the inside of changeattribute function " + getAtribute.value);
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

