function solve(speed, area) {
    let status='';
    if (area == 'city') {
        if (speed > 50) {
            let speeding = speed - 50;
            logSpeeding(speeding);
            console.log('The speed is '+ speeding+' km/h faster than the allowed speed of 50 - ' +status);
        }
        else{
            console.log('Driving ' + speed +' km/h in a 50 zone' )
        }
    } 
    else if (area == 'motorway') {
        if (speed > 130) {
            let speeding = speed - 130;
            logSpeeding(speeding);
            console.log('The speed is '+ speeding+' km/h faster than the allowed speed of 130 - ' +status);
        }
        else{
            console.log('Driving ' + speed +' km/h in a 130 zone' )
        }
    } 
    else if (area == 'interstate') {
        if (speed > 90) {
            let speeding = speed - 90;
            logSpeeding(speeding);
            console.log('The speed is '+ speeding+' km/h faster than the allowed speed of 90 - ' +status);
        }
        else{
            console.log('Driving ' + speed +' km/h in a 90 zone' )
        }
    } 
    else if (area == 'residential') {
        if (speed > 20) {
            let speeding = speed - 20;
            logSpeeding(speeding);
            console.log('The speed is '+ speeding+' km/h faster than the allowed speed of 20 - ' +status);
        }
        else{
            console.log('Driving ' + speed +' km/h in a 20 zone' )
        }
    }
 
    function logSpeeding(speeding) {
        if (speeding <= 20) {
            status='speeding';
        } 
        else if (speeding <= 40) {
            status='excessive speeding';
        } 
        else {
            status='reckless driving';
        }
    }
}

solve(21,'residential')