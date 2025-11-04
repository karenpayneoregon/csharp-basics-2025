(function () {
    function applyHeights() {
        const header = document.querySelector('body > header');
        const footer = document.querySelector('.footer'); // footer is absolute in your layout:contentReference[oaicite:0]{index=0}
        const navH = header ? header.offsetHeight : 0;
        const footH = footer ? footer.offsetHeight : 60; // your footer uses ~60px line-height:contentReference[oaicite:1]{index=1}
        const root = document.documentElement;
        root.style.setProperty('--nav-h', navH + 'px');
        root.style.setProperty('--foot-h', footH + 'px');
    }
    applyHeights();
    window.addEventListener('resize', applyHeights, { passive: true });
})();