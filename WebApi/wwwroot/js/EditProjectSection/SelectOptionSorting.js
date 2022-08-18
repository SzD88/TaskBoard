src = "https://ajax.googleapis.com/ajax/libs/jquery/2.1.1/jquery.min.js";

function createSelectOptionList()
{
    // przerob te klase i pobierz tutaj get - zapisz wszystko do listy i on z tej listy juz
    //tworzyc bedzie bo zobacz do maina 
    const allOptions = document.createElement("div");

    const optionTest = document.createElement("option");
    var name = document.createTextNode("Volvo");
    optionTest.appendChild(name);
    const optionTest2 = document.createElement("option");
    var name2 = document.createTextNode("Volvo");
    optionTest.appendChild(name2);

    allOptions.appendChild(optionTest2);
    allOptions.appendChild(optionTest);

    return allOptions;

}


