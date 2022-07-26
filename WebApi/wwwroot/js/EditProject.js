var projectId;
let idToUse;
let titleToUse;
let descriptionToUse;

window.onload = function () {
    // splits url to get id transfered from main.js
    var url = document.location.href,
        params = url.split('?')[1].split('&'),
        data = {}, tmp;
    for (var i = 0, l = params.length; i < l; i++) {
        tmp = params[i].split('=');
        data[tmp[0]] = tmp[1];
    }


    var output = data.id;
    projectId = data.id;

    InputDataToForm("/api/Project/" + projectId);
}

async function InputDataToForm(pathToGetById) {
    let x = await fetch(pathToGetById);
    let y = await x.json();
    // console.log(y);  // returns json of 1 acurate project

    //redirect to editProjecthtml
    idToUse = y.id;
    titleToUse = y.title;
    descriptionToUse = y.description;


    inputValuesToForm(idToUse, titleToUse, descriptionToUse);
}

// it is the function on click "Zatwierdz zmiany"
function replaceFormValuesToInputed() //changes all fields to filled //or dont change if no changes
{
    console.log("just before override fields " + descriptionToUse);
    var idFromUpdatedForm = changeAttributeByName("projectNumber");
    var titleFromUpdatedForm = changeAttributeByName("title");
    var descriptionFromUpdatedForm = changeAttributeByName("description");

    putDataFromFieldsToDatabase(idFromUpdatedForm, titleFromUpdatedForm, descriptionFromUpdatedForm);
}

async function putDataFromFieldsToDatabase(id, title, desc) {

    var projJson = createJSON(title, desc); //works

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

function createJSON(title, description) {
    var projectJSON = {
        "id": idToUse,
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

function inputValuesToForm(idToUse, titleToUse, descriptionToUse) {
    document.getElementById('projectNumber').setAttribute('value', idToUse);
    document.getElementById('title').setAttribute('value', titleToUse);
    document.getElementById('description').setAttribute('value', descriptionToUse);
    console.log(descriptionToUse);
    //override variables

    var idToUse = document.getElementById('projectNumber').getAttribute("value");
    var titleToUse = document.getElementById('title').getAttribute("value");
    var descriptionToUse = document.getElementById('description').getAttribute("value");
    console.log(descriptionToUse); 
}

