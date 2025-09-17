Here’s a clean, copy-pasteable login form with minimal boilerplate. 
HTML

```html
<div class="login-container">
  <form class="login-form" method="post" action="#">
    <h1 class="login-title">Sign in</h1>

    <div class="form-field">
      <label for="username">Username</label>
      <input id="username" name="username" type="text" required autocomplete="username" />
    </div>

    <div class="form-field">
      <label for="password">Password</label>
      <input id="password" name="password" type="password" required autocomplete="current-password" />
    </div>

    <button type="submit" class="btn-submit">Sign in</button>
  </form>
</div>
```

CSS

```css
/* Scoped login form styles */
.login-container {
  min-height: 60vh;
  display: grid;
  place-items: center;
  padding: 2rem;
  background: #f7f7f9;
  font-family: 'Cascadia Code', monospace;
}

.login-form {
  width: 100%;
  max-width: 380px;
  padding: 1.75rem;
  border-radius: 12px;
  background: #fff;
  box-shadow: 0 8px 24px rgba(0, 0, 0, 0.08);
}

.login-title {
  margin: 0 0 1rem 0;
  font-size: 1.5rem;
  font-weight: 600;
  text-align: center;
  color: #222;
}

.form-field {
  margin-bottom: 1rem;
}

.form-field label {
  display: block;
  margin-bottom: 0.5rem;
  font-size: 0.95rem;
  color: #333;
}

.form-field input[type="text"],
.form-field input[type="password"] {
  width: 100%;
  height: 42px;
  padding: 0 0.75rem;
  border: 1px solid #d0d5dd;
  border-radius: 8px;
  background: #fff;
  color: #111;
  font-size: 0.95rem;
  font-family: 'Cascadia Code', monospace;
  transition: border-color 0.15s ease, box-shadow 0.15s ease;
  outline: none;
  box-sizing: border-box;
}

.form-field input::placeholder {
  color: #9aa3b2;
}

.form-field input:focus {
  border-color: #258cfb;
  box-shadow: 0 0 0 0.2rem rgba(37, 140, 251, 0.15);
}

.btn-submit {
  width: 100%;
  height: 44px;
  border: 0;
  border-radius: 8px;
  background: #258cfb;
  color: #fff;
  font-weight: 600;
  font-size: 1rem;
  cursor: pointer;
  font-family: 'Cascadia Code', monospace;
  transition: transform 0.08s ease, box-shadow 0.15s ease, background 0.15s ease;
}

.btn-submit:hover {
  background: #1e73cf;
  box-shadow: 0 6px 18px rgba(37, 140, 251, 0.25);
}

.btn-submit:active {
  transform: translateY(1px);
}
```

Notes:
- Paste the HTML into your Razor Page (e.g., Pages/Login.cshtml) body.
- Add the CSS to your stylesheet (e.g., wwwroot/css/site.css) or include it in a page-specific CSS file.
- The markup is framework-agnostic and works seamlessly in Razor Pages.