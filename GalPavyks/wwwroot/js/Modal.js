
function OpenDeleteModal(PersonId) {
    console.log("Person:");
    console.log(PersonId);
    $(".modal-body span").text("Person ID: " + PersonId);
    $("#DeletePersonButton").attr("href", "DeletePerson/"+PersonId);
    

    
    $("#showmodal").modal();
  

}
