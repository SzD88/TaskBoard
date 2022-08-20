src = "https://ajax.googleapis.com/ajax/libs/jquery/2.1.1/jquery.min.js";

async function createSelectOptionList()
{
    
        var x = document.getElementById("select");

        var selectOptionsList = await getSortFields();
        console.log(selectOptionsList);
        console.log("test");
        // w tej funkcji fetch z endpointa zwracajacego pola i te pola tutaj po kolei append w osobnej funkcji
        for (numerator in selectOptionsList) {
             
            var option = document.createElement("option");
            option.text = selectOptionsList[numerator];

            x.add(option); 
        }


  }


