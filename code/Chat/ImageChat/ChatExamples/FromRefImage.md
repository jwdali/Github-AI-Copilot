Generate HTML and CSS based on this image. Do not use any resources, css or html from this solution.

Based on the login form image you've provided, I'll create HTML and CSS that recreates this design. The image shows a modern login interface with a dark gradient background, an illustrated character, and clean form elements.

```html
<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Login</title>
    <link rel="stylesheet" href="styles.css">
</head>
<body>
    <div class="login-container">
        <div class="login-card">
            <div class="character-illustration">
                <div class="character">
                    <div class="character-head"></div>
                    <div class="character-body"></div>
                    <div class="character-arm-left"></div>
                    <div class="character-arm-right"></div>
                    <div class="character-hands"></div>
                </div>
            </div>
            
            <h1 class="login-title">LOGIN</h1>
            
            <form class="login-form">
                <div class="input-group">
                    <input type="text" id="username" placeholder="USERNAME" required>
                </div>
                
                <div class="input-group">
                    <input type="password" id="password" placeholder="PASSWORD" required>
                </div>
                
                <button type="submit" class="submit-btn">SUBMIT</button>
            </form>
            
            <div class="login-footer">
                <a href="#" class="footer-link">REGISTER</a>
                <a href="#" class="footer-link">FORGOT PASSWORD</a>
            </div>
        </div>
    </div>
</body>
</html>
```
```css
* {
    margin: 0;
    padding: 0;
    box-sizing: border-box;
}

body {
    font-family: 'Arial', sans-serif;
    background: linear-gradient(135deg, #1e3c72 0%, #2a5298 50%, #1e3c72 100%);
    min-height: 100vh;
    display: flex;
    align-items: center;
    justify-content: center;
    overflow: hidden;
}

.login-container {
    width: 100%;
    max-width: 400px;
    padding: 20px;
}

.login-card {
    background: rgba(30, 40, 70, 0.9);
    border-radius: 20px;
    padding: 40px 30px;
    box-shadow: 0 20px 40px rgba(0, 0, 0, 0.3);
    backdrop-filter: blur(10px);
    border: 1px solid rgba(255, 255, 255, 0.1);
    position: relative;
    text-align: center;
}

.character-illustration {
    position: absolute;
    top: -80px;
    right: -60px;
    width: 200px;
    height: 200px;
}

.character {
    position: relative;
    width: 100%;
    height: 100%;
}

.character-head {
    position: absolute;
    top: 20px;
    right: 60px;
    width: 40px;
    height: 40px;
    background: #ffdbcc;
    border-radius: 50%;
    border: 2px solid #e8b896;
}

.character-body {
    position: absolute;
    top: 50px;
    right: 40px;
    width: 80px;
    height: 100px;
    background: linear-gradient(45deg, #ff6b35, #ff8c42);
    border-radius: 40px 40px 10px 10px;
    box-shadow: 0 5px 15px rgba(0, 0, 0, 0.2);
}

.character-arm-left {
    position: absolute;
    top: 65px;
    right: 110px;
    width: 35px;
    height: 15px;
    background: #ff6b35;
    border-radius: 10px;
    transform: rotate(-20deg);
}

.character-arm-right {
    position: absolute;
    top: 65px;
    right: 15px;
    width: 35px;
    height: 15px;
    background: #ff6b35;
    border-radius: 10px;
    transform: rotate(20deg);
}

.character-hands {
    position: absolute;
    top: 75px;
    right: 45px;
    width: 70px;
    height: 25px;
    background: #ffdbcc;
    border-radius: 15px;
    border: 2px solid #e8b896;
}

.login-title {
    color: #a8b2c1;
    font-size: 2.5rem;
    font-weight: bold;
    margin-bottom: 40px;
    letter-spacing: 3px;
    text-shadow: 2px 2px 4px rgba(0, 0, 0, 0.3);
}

.login-form {
    margin-bottom: 30px;
}

.input-group {
    margin-bottom: 20px;
}

.input-group input {
    width: 100%;
    padding: 15px 20px;
    background: rgba(255, 255, 255, 0.1);
    border: 1px solid rgba(255, 255, 255, 0.2);
    border-radius: 10px;
    color: #a8b2c1;
    font-size: 14px;
    font-weight: bold;
    letter-spacing: 1px;
    backdrop-filter: blur(5px);
    transition: all 0.3s ease;
}

.input-group input::placeholder {
    color: #6b7280;
    font-weight: bold;
    letter-spacing: 1px;
}

.input-group input:focus {
    outline: none;
    border-color: rgba(255, 255, 255, 0.4);
    background: rgba(255, 255, 255, 0.15);
    box-shadow: 0 0 15px rgba(42, 82, 152, 0.3);
}

.submit-btn {
    width: 100%;
    padding: 15px;
    background: linear-gradient(45deg, #2563eb, #3b82f6);
    color: white;
    border: none;
    border-radius: 10px;
    font-size: 16px;
    font-weight: bold;
    letter-spacing: 2px;
    cursor: pointer;
    transition: all 0.3s ease;
    box-shadow: 0 5px 15px rgba(37, 99, 235, 0.3);
}

.submit-btn:hover {
    background: linear-gradient(45deg, #1d4ed8, #2563eb);
    transform: translateY(-2px);
    box-shadow: 0 8px 25px rgba(37, 99, 235, 0.4);
}

.submit-btn:active {
    transform: translateY(0);
}

.login-footer {
    display: flex;
    justify-content: space-between;
    gap: 20px;
}

.footer-link {
    color: #6b7280;
    text-decoration: none;
    font-size: 12px;
    font-weight: bold;
    letter-spacing: 1px;
    transition: color 0.3s ease;
}

.footer-link:hover {
    color: #a8b2c1;
}

/* Responsive design */
@media (max-width: 480px) {
    .login-container {
        padding: 10px;
    }
    
    .login-card {
        padding: 30px 20px;
    }
    
    .character-illustration {
        display: none;
    }
    
    .login-title {
        font-size: 2rem;
    }
    
    .login-footer {
        flex-direction: column;
        gap: 10px;
        text-align: center;
    }
}
```

This implementation recreates the login form from your image with the following key features:

**Design Elements:**
- Dark gradient background matching the original
- Semi-transparent card with backdrop blur effect
- Illustrated character positioned in the top-right corner
- Clean, modern typography with proper spacing

**Form Components:**
- Username and password input fields with placeholder text
- Styled submit button with gradient background
- Register and "Forgot Password" links at the bottom

**Styling Details:**
- Glassmorphism effect on the login card
- Smooth hover animations and transitions
- Responsive design that hides the character illustration on mobile
- Color scheme matching the original design

The character illustration is created using CSS shapes and positioned to match the original design. The form maintains the same visual hierarchy and styling as shown in your image.