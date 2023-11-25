async function GETTime(){
    const response = await fetch("/time",{
        method: "GET",
        headers:{"Accept":"application/json"},
        //body: JSON.stringify()
    });
    if(response.ok === true){
        const time = await response.json();
        var TimeBlock = document.getElementById("Time");
        TimeBlock.append(time);
        setTimeout(()=>{
            window.location.reload(true);
        },59444);
        // 
        TimeBlock.setTimeout();
        
        console.log(time);
        return;
    }
    else{
        const error = await response.json();
        console.log(error.message);
    }
}