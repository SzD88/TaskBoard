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

    inputValuesToForm(idToUse, titleToUse, descriptionToUse)
}


function replaceFormValuesToInputed() //changes all fields to filled //or dont change if no changes
{

    //changing current attribute
    //var getAtribute = document
    //    .getElementById('projectNumber');
    //var attributeChanged = getAtribute.value.replace();
    //getAtribute.value = attributeChanged;
    changeAttributeByName("projectNumber")
    changeAttributeByName("title")
    changeAttributeByName("description")

    // now fetch
    let x = await fetch(pathToGetById);
    let y = await x.json();

    //public string Title { get; set; }
    //  public string Description { get; set; }
    //  public bool Completed { get; set; }
    createJSON(titleToUse, descriptionToUse)

    function createJSON(title, description) {

        const projectJSON = { 
            "title": title,
            "description": description,
            "completed": false // change it later !!
         }
        console.log(projectJSON);
    };
    const jsonString = JSON.stringify(customer);
}

function changeAttributeByName(attributeName) {
    var getAtribute = document
        .getElementById(attributeName);
    var attributeChanged = getAtribute.value.replace();
    getAtribute.value = attributeChanged;

    console.log(getAtribute.value);
    return getAtribute.value;
}
}

function inputValuesToForm(idToUse, titleToUse, descriptionToUse) {
    document.getElementById('projectNumber').setAttribute('value', idToUse);
    document.getElementById('title').setAttribute('value', titleToUse);
    document.getElementById('description').setAttribute('value', descriptionToUse);

}