let task_content_list = [];

const container = document.getElementById("container");
fetch('api/SubTask')
    .then(response => {
        if (response.ok) {
            return response.json();
        } else {
            throw new Error(response.statusText);
        } 
    })
    .then(data => {
        task_content_list = data; 
        for (nextTask in task_content_list) {
            let singleObj = task_content_list[nextTask].id;
            let li = document.createElement("li");
            let node = document.createTextNode(singleObj);
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