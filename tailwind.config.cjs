/** @type {import('tailwindcss').Config} */
module.exports = {
    content: [
        "./Components/**/*.{razor,html,cshtml}",
        "./Pages/**/*.{razor,html,cshtml}",
        "./Shared/**/*.{razor,html,cshtml}",
        "./wwwroot/index.html"
    ],
    theme: {
        extend: {},
    },
    plugins: [
        require('@tailwindcss/forms'),
    ],
};
