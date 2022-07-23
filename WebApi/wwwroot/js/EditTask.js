function func1(input)
{ 
    getText('api/Project/'+input);
    ///==============
    async function getText(file) {
        let x = await fetch(file);
        let y = await x.json();
        console.log(y);
    }

}