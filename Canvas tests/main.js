const canvas = document.getElementById("some-canvas");
const context = canvas.getContext("2d");

// default W = 300
// default H = 150

var score = 0;

canvas.width = 800;
canvas.height = 600;

// user mouse coordinates
var xMouse = 0;
var yMouse = 0;

// actual count is obstaclesCount ^ 2
var obstaclesCount = 2;

// ball data
var xCord = 0;
var yCord = 0;
var xVelocity = 0;
var yVelocity = 5;
var ballRadius = 10;
var arcStartAngle = 0;
var arcEndAngle = Math.PI * 2;

// starting point to draw obstacles, drawing needs improvement
var obstacleXCord = 80;
var obstacleYCord = 100;
var obstacleWidth = 50;
var obstacleHeight = 30;

var multipliers = [];

fillMultipliers();

function fillMultipliers() {
    for(let i = 0; i < obstaclesCount; i += 1) {
        for(let j = 0; j < obstaclesCount; j += 1) {
            multipliers.push({'x':i, 'y':j});
        }        
    }

    console.log(multipliers);
}

function collidedWithObstacle() {

    for(let i = 0; i < obstaclesCount; i += 1) {
        for(let j = 0; j < obstaclesCount; j += 1) {
            if(multipliers.findIndex(smth => smth.x === i && smth.y === j) === -1) {
                continue;
            }

            let obstacleLeftX = obstacleXCord + (obstacleXCord + obstacleWidth) * i;
            let obstacleRightX = obstacleXCord + (obstacleXCord + obstacleWidth) * i + obstacleWidth;
            let obstacleTopY = obstacleYCord + (obstacleYCord + obstacleHeight) * j;
            let obstacleBottomY = obstacleYCord + (obstacleYCord + obstacleHeight) * j + obstacleHeight;

            if((xCord + ballRadius >= obstacleLeftX && xCord - ballRadius <= obstacleRightX) &&
                (yCord + ballRadius >= obstacleTopY && yCord - ballRadius <= obstacleBottomY)) {
                    multipliers.splice(multipliers.findIndex(smth => smth.x === i && smth.y === j), 1);
                    document.getElementById("score").innerHTML = "Score: " + (++score);
                    return true;
                }
        }
    }

    return false;
}

function collidedWithPlatform() {
    if(yCord >= canvas.height - 10) {
        if(xCord <= xMouse - 150 || xCord >= xMouse + 150) {
            return false;
        }
        else {
            // modify angles
            if(xCord >= xMouse - 150 && xCord <= xMouse - 100) {
                xVelocity += -4;
            }
            else if(xCord >= xMouse - 101 && xCord <= xMouse -50) {
                xVelocity += -3;
            }            
            else if(xCord >= xMouse - 51 && xCord <= xMouse) {
                xVelocity += -1;
            }            
            else if(xCord >= xMouse + 1  && xCord <= xMouse + 50) {
                xVelocity += 1;
            }
            
            else if(xCord >= xMouse + 51 && xCord <= xMouse + 100) {
                xVelocity += 3;
            }
            else {
                xVelocity += 4;
            }
        }
    }

    return true;
}

function drawObstacles(obstaclesCount) {
    for(let i = 0; i < obstaclesCount; i += 1) {
        for(let j = 0; j < obstaclesCount; j += 1) {            
            if(multipliers.findIndex(smth => smth.x === i && smth.y === j) === -1) {
                continue;
            }
            context.fillRect(obstacleXCord + (obstacleXCord + obstacleWidth) * i, obstacleYCord + (obstacleYCord + obstacleHeight) * j, obstacleWidth, obstacleHeight);
        }
    }
}

function draw() {
    context.clearRect(0, 0, canvas.width, canvas.height);

    context.fillStyle = "Red";  
    drawObstacles(obstaclesCount);

    // context.fillRect(xCord, yCord, 10, 10);
    context.beginPath();
    context.fillStyle = "Green";
    context.arc(xCord, yCord, ballRadius, arcStartAngle, arcEndAngle);
    context.fill();
    
    context.stroke();

    if(multipliers.length === 0) {
        context.clearRect(0, 0, canvas.width, canvas.height);
        
        context.font = "40px Arial";
        context.fillText("YOU WIN! SCORE: " + score, canvas.width / 4, canvas.height / 2, 500);
        return;
    }

    if(!collidedWithPlatform()) {
        context.font = "40px Arial";
        context.fillText("RIP! SCORE: " + score, canvas.width / 4, canvas.height / 2, 500);
        return;
    }

    if(xCord + xVelocity <= 0 || xCord + xVelocity >= canvas.width) {
        xVelocity *= -1;
    }

    if(yCord + yVelocity <= 0 || yCord + yVelocity >= canvas.height) {
        yVelocity *= -1;
    }

    if(collidedWithObstacle()) {
        xVelocity *= -1;
        yVelocity *= -1;
    }



    xCord += xVelocity;
    yCord += yVelocity;

    context.fillRect(xMouse - 150, canvas.height - 15, 300, 20);

    window.requestAnimationFrame(draw);
}

draw();

// fillRect(xCord, yCord, width, height)
// clearRect(xCord, yCord, width, height)


// detect mouse coordinates



function getMousePos(canvas, evt) {
        var rect = canvas.getBoundingClientRect();
        return {
          x: evt.clientX - rect.left,
          y: evt.clientY - rect.top
        };
      }


canvas.addEventListener('mousemove', function(evt) {
        var mousePos = getMousePos(canvas, evt);
        var message = 'Mouse position: ' + mousePos.x + ',' + mousePos.y;

        xMouse = mousePos.x;
        yMouse = mousePos.y;
      }, false);