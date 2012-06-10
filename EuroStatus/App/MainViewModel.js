function PlayerViewModel() {
    var self = this;
    self.index = ko.observable();
    self.name = ko.observable();
    self.score = ko.observable();
    self.games = ko.observableArray();

    self.gridViewModel = new ko.simpleGrid.viewModel({
        data: self.games,
        columns: [

            { headerText: "Team A", rowText: "teamA" },
            { headerText: "Score", rowText: "teamAScore" },
            { headerText: "Team B", rowText: "teamB" },
            { headerText: "Score", rowText: "teamBScore" },

            
            

        ], pageSize: 20

    });
}

function GameViewModel() {
    var self = this;
    self.teamA = ko.observable();
    self.teamB = ko.observable();
    self.teamAScore = ko.observable();
    self.teamBScore = ko.observable();
}


function MainViewModel() {
    // Data
    var self = this;
    self.currentPlayer = ko.observable();
    
    self.players = ko.observableArray();

    self.players.subscribe(function () {
        for (var i = 0, j = self.players().length; i < j; i++) {
            var item = self.players()[i];
                if (!item.index) {
                    item.index = ko.observable((i+1));
                } else {
                    item.index((i + 1));
                }
            }
        });

        $.getJSON("/api/apiAccess", function (data) {
            //var vm = ko.mapping.fromJS(data);

            // Now use this data to update your view models, 
            // and Knockout will update your UI automatically 
            $.each(data, function (i, p) {
                var vm = new PlayerViewModel();
                vm.name(p.Name);
                vm.score(p.Score);
                $.each(p.Games, function(j, g) {
                    var game = new GameViewModel();
                    game.teamA(g.TeamA);
                    game.teamB(g.TeamB);
                    game.teamAScore(g.TeamAScore);
                    game.teamBScore(g.TeamBScore);
                    vm.games.push(game);
                });


                self.players.push(vm);
            });

            self.players.sort(function (left, right) { return left.score() == right.score() ? 0 : (left.score() > right.score() ? -1 : 1) });



        });



    self.nav = new NavHistory({
        params: { view: 'table', playerName: null },
        onNavigate: function (navEntry) {
          if (navEntry.params.playerName === "") {
              self.currentPlayer(null);
              
          }
        }
    });
    self.nav.initialize({ linkToUrl: true });
    self.showPlayer = function (player) {
        self.currentPlayer(player);
        self.nav.navigate({ view: 'player', playerName: player.name() });
    };
    self.showTable = function() {
        self.nav.navigate({ view: 'table'});
    };
    
    
}




