function getProjectSiteById(input) {

    redirectToProjectPage('api/Project/' + input);
    ///==============
    async function redirectToProjectPage(file) {
        let x = await fetch(file);
        let y = await x.json();
        console.log(y);  // returns json of 1 acurate project

        //redirect to editProjecthtml
        let idToUse = y.id;
        let titleToUse = y.title;
        let descriptionToUse = y.description;
        //call method ... and send json
        location.replace("/editproject.html"), 1000;

        console.log(idToUse + " " + titleToUse + " " + descriptionToUse);

        //there deserialize it 
        console.log("przed funkcja input input funkcji ");
        // before this we need to call function
        inputValuesToForm(idToUse, titleToUse, descriptionToUse), 2000; //delay 
        console.log("po input funkcji ");
    }
}

function replaceFormValuesToInputed() //changes all fields to filled //or dont change if no changes
{
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