let dog_list = [];

const container = document.getElementById("container");
fetch('api/SubTask')
    .then(response => {
        if (response.ok) {
            return response.json();
        } else {
            throw new Error(response.statusText);
        } //   <ul id="container"></ul>
    })
    .then(data => {
        dog_list = data[1].id;
        console.log(data[1].id)
        for (dog in dog_list) {
            let li = document.createElement("li");
            let node = document.createTextNode(dog);
            li.appendChild(node);
            container.appendChild(li);
        }
    });


//let dog_list = [];

//const container = document.getElementById("container");
//fetch('https://dog.ceo/api/breeds/list/all')
//    .then(response => {
//        if (response.ok) {
//            return response.json();
//        } else {
//            throw new Error(response.statusText);
//        } //   <ul id="container"></ul>
//    })
//    .then(data => {
//        dog_list = data.message;
//        for (dog in dog_list) {
//            let li = document.createElement("li");
//            let node = document.createTextNode(dog);
//            li.appendChild(node);
//            container.appendChild(li);
//        }
//    });