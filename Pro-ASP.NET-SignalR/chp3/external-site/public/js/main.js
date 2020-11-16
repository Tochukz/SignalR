/** Using Cross Origin SignalR */
$(function() {
  const baseUrl = "https://localhost:44359";
  $.ajaxSetup({
    beforeSend: (xhr, settings) => {    
      settings.url = `${baseUrl}${settings.url}`
    }
  });
  const broadcaster = $.connection.helloHub;
  broadcaster.connection.baseUrl = baseUrl; 
  broadcaster.client.displayText = text => {
    $('#messages').append(`<li>${text}</li>`);
  };
  $.connection.hub.start().done(() => {
    $('#broadcast').click(() => {
      broadcaster.server.broadcastMessage($('#msg').val());
    });
  });
});
