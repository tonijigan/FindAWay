mergeInto(LibraryManager.library, {
  GetPlayerInfo: function(){

    myGameInstance.SendMessage('Yandex', 'SetName',player.getName());
    myGameInstance.SendMessage('Yandex', 'SetImage',player.getPhoto("medium"));
  },
});