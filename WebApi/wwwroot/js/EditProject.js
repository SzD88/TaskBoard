var projectId;
window.onload = function () {
    // splits url to get id transfered from main.js
    var url = document.location.href,
        params = url.split('?')[1].split('&'),
        data = {}, tmp;
    //console.log(url); 
    for (var i = 0, l = params.length; i < l; i++) {
        tmp = params[i].split('=');
        data[tmp[0]] = tmp[1];
    }
    var output = data.id;
    console.log("this is data : " + output);
    projectId = data.id;

    InputDataToForm("/api/Project/" + projectId);
}

    async function InputDataToForm(pathToGetById) {
        let x = await fetch(pathToGetById);
        let y = await x.json();
        console.log(y);  // returns json of 1 acurate project

        //redirect to editProjecthtml
        let idToUse = y.id;
        let titleToUse = y.title;
        let descriptionToUse = y.description;
        
        console.log(idToUse + " " + titleToUse + " " + descriptionToUse); // dotad działa 
 
       // window.location.replace("/editproject.html"), 1000;  /// tutaj lapie !!!!!!!!!!!!!
 
        console.log("po przejsciu na editproject page ");

        inputValuesToForm(idToUse, titleToUse, descriptionToUse)
    }


function replaceFormValuesToInputed() //changes all fields to filled //or dont change if no changes
{
    console.log(idToTransfer);
    //changing current attribute
    var getAtribute = document
        .getElementById('projectNumber');
    var attributeChanged = getAtribute.value.replace();
    getAtribute.value = attributeChanged;

    console.log(getAtribute.value);
}

function inputValuesToForm(idToUse, titleToUse, descriptionToUse) {
    document.getElementById('projectNumber').setAttribute('value', idToUse);
    document.getElementById('title').setAttribute('value', titleToUse);
    document.getElementById('description').setAttribute('value', descriptionToUse);

}