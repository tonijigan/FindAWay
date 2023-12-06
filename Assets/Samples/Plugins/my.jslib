mergeInto(LibraryManager.library, {
  GetPlayerInfo: function(){
       myGameInstance.SendMessage('Yandex', 'SetName',player.getName());
       myGameInstance.SendMessage('Yandex', 'SetImage',player.getPhoto("medium")); 
  },

   RateGame: function(){

   ysdk.feedback.canReview()
        .then(({ value, reason }) => {
            if (value) {
                ysdk.feedback.requestReview()
                    .then(({ feedbackSent }) => {
                        console.log(feedbackSent);
                    })
            } else {
                console.log(reason)
            }
        })
  },

  SaveExtern: function(date){
    var dataString = UTF8ToString(date);
    var myObject = JSON.parse(dataString);
    player.setData(myObject);
  },

  LoadExtern: function(){
    player.getData().then(_date =>{
        const myJSON = JSON.stringify(_date);
        myGameInstance.SendMessage('PlrogressTest','SetPlayerInfo', myJSON);
    });
  },
});