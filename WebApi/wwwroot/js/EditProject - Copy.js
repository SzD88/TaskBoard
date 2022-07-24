function getProjectSiteById(input)
{ 
    redirectToProjectPage('api/Project/'+ input);
    ///==============
    async function redirectToProjectPage(file) {
        let x = await fetch(file);
        let y = await x.json();
        console.log(y);  // returns json of 1 acurate project

        //redirect to editProjecthtml
        let idToUse = y.id;
        let titleToUse = y.title;
        let descriptionToUse = y.description;
        console.log(idToUse + " " + titleToUse + " " + descriptionToUse );
        //call method ... and send json
        location.replace("/editproject.html");

        //there deserialize it 
        console.log("przed funkcja input input funkcji ");
        // before this we need to call function
        inputValuesToForm(idToUse, titleToUse, descriptionToUse), 2000; //delay 
        console.log("po input funkcji ");
    }
   
}