// Optimized Blazor Server Kaleidoscope Generator
console.log('Optimized kaleidoscope generator loading...');

// Constants for better maintainability
const KALEIDOSCOPE_CONFIG = {
    SEGMENTS: 12,
    SEGMENT_ANGLE: Math.PI / 6, // 30 degrees
    MIN_ELEMENTS: 15,
    MAX_ADDITIONAL_ELEMENTS: 10,
    MIN_SIZE: 8,
    MAX_SIZE: 28,
    RADIUS_MULTIPLIER: 0.8,
    BLAZOR_READY_TIMEOUT: 5000, // 5 seconds
    GENERATION_DELAY: 150
};

// Pre-defined color palettes for better performance
const COLOR_PALETTES = [
    ['#ff006e', '#fb5607', '#ffbe0b', '#8338ec', '#3a86ff'],
    ['#f72585', '#b5179e', '#7209b7', '#480ca8', '#3f37c9'],
    ['#ff9500', '#ff5400', '#ff006e', '#c77dff', '#7209b7'],
    ['#06ffa5', '#1cb5e0', '#000cff', '#7209b7', '#f72585'],
    ['#ffd60a', '#003566', '#001d3d', '#ffd166', '#f77f00'],
    ['#e63946', '#f77f00', '#fcbf49', '#003566', '#0077b6'],
    ['#d62828', '#f77f00', '#fcbf49', '#003566', '#0077b6']
];

// Shape configurations for consistency
const SHAPE_CONFIG = {
    petal: { spikes: 4, innerRatio: 0.5 },
    star: { spikes: 6, innerRatio: 0.5 },
    diamond: { facetRatio: 0.7 }
};

// Blazor Server readiness check
function waitForBlazorServer(callback, maxAttempts = 20) {
    let attempts = 0;
    const startTime = Date.now();
    
    function checkBlazorReady() {
        attempts++;
        const blazorReady = window.Blazor?.start || typeof DotNet !== 'undefined';
        const timedOut = Date.now() - startTime > KALEIDOSCOPE_CONFIG.BLAZOR_READY_TIMEOUT;
        
        if (blazorReady || attempts >= maxAttempts || timedOut) {
            console.log(`Blazor ready check completed: attempts=${attempts}, ready=${!!blazorReady}`);
            callback();
        } else {
            setTimeout(checkBlazorReady, 250);
        }
    }
    
    checkBlazorReady();
}

class OptimizedKaleidoscope {
    constructor(canvas) {
        this.canvas = canvas;
        this.ctx = canvas.getContext('2d');
        this.updateDimensions();
        
        // Cache frequently used values
        this.segmentAngle = (2 * Math.PI) / KALEIDOSCOPE_CONFIG.SEGMENTS;
        this.shapes = ['petal', 'star', 'diamond'];
        
        console.log(`Kaleidoscope initialized: ${this.width}x${this.height}, radius: ${this.radius}`);
    }

    updateDimensions() {
        this.width = this.canvas.width;
        this.height = this.canvas.height;
        this.centerX = this.width / 2;
        this.centerY = this.height / 2;
        this.radius = Math.min(this.width, this.height) / 2 - 10;
    }

    // Optimized color palette selection
    getColorPalette() {
        return COLOR_PALETTES[Math.floor(Math.random() * COLOR_PALETTES.length)];
    }

    // Cached gradient creation with error handling
    createGradient(x, y, radius, colors) {
        try {
            const gradient = this.ctx.createRadialGradient(x, y, 0, x, y, radius);
            const step = 1 / (colors.length - 1);
            
            colors.forEach((color, index) => {
                gradient.addColorStop(index * step, color);
            });
            
            return gradient;
        } catch (error) {
            // Graceful degradation to solid color
            return colors[0];
        }
    }

    // Optimized petal drawing with reduced calculations
    drawPetal(x, y, size, rotation, colors) {
        this.ctx.save();
        this.ctx.translate(x, y);
        this.ctx.rotate(rotation);
        
        try {
            // Main petal body
            this.ctx.fillStyle = this.createGradient(0, 0, size, colors);
            this.ctx.beginPath();
            
            const cp = size * 0.6; // Control point
            const mp = size * 0.3; // Mid point
            
            this.ctx.moveTo(0, -size);
            this.ctx.quadraticCurveTo(cp, -mp, mp, 0);
            this.ctx.quadraticCurveTo(cp, mp, 0, size);
            this.ctx.quadraticCurveTo(-cp, mp, -mp, 0);
            this.ctx.quadraticCurveTo(-cp, -mp, 0, -size);
            this.ctx.fill();
            
            // Inner highlight - optimized
            if (colors.length > 1) {
                this.ctx.fillStyle = colors[colors.length - 1] + '80';
                this.ctx.beginPath();
                this.ctx.ellipse(0, 0, size * 0.2, size * 0.4, 0, 0, Math.PI * 2);
                this.ctx.fill();
            }
        } catch (error) {
            this.drawFallbackCircle(colors[0], size);
        }
        
        this.ctx.restore();
    }

    // Optimized star drawing
    drawStar(x, y, size, rotation, colors) {
        this.ctx.save();
        this.ctx.translate(x, y);
        this.ctx.rotate(rotation);
        
        try {
            const config = SHAPE_CONFIG.star;
            const outerRadius = size;
            const innerRadius = size * config.innerRatio;
            const angleStep = Math.PI / config.spikes;
            
            this.ctx.fillStyle = this.createGradient(0, 0, size, colors);
            this.ctx.beginPath();
            
            // Generate star points more efficiently
            for (let i = 0; i < config.spikes * 2; i++) {
                const radius = i % 2 === 0 ? outerRadius : innerRadius;
                const angle = i * angleStep;
                const px = Math.cos(angle) * radius;
                const py = Math.sin(angle) * radius;
                
                if (i === 0) this.ctx.moveTo(px, py);
                else this.ctx.lineTo(px, py);
            }
            
            this.ctx.closePath();
            this.ctx.fill();
            
            // Center highlight
            if (colors.length > 2) {
                this.ctx.fillStyle = colors[Math.floor(colors.length / 2)];
                this.ctx.beginPath();
                this.ctx.arc(0, 0, size * 0.3, 0, Math.PI * 2);
                this.ctx.fill();
            }
        } catch (error) {
            this.drawFallbackCircle(colors[0], size);
        }
        
        this.ctx.restore();
    }

    // Optimized diamond drawing
    drawDiamond(x, y, size, rotation, colors) {
        this.ctx.save();
        this.ctx.translate(x, y);
        this.ctx.rotate(rotation);
        
        try {
            const facet = size * SHAPE_CONFIG.diamond.facetRatio;
            
            // Main diamond body
            this.ctx.fillStyle = colors[Math.floor(Math.random() * colors.length)];
            this.ctx.beginPath();
            this.ctx.moveTo(0, -size);
            this.ctx.lineTo(facet, 0);
            this.ctx.lineTo(0, size);
            this.ctx.lineTo(-facet, 0);
            this.ctx.closePath();
            this.ctx.fill();
            
            // Facet highlight
            this.ctx.fillStyle = colors[colors.length - 1] + '60';
            this.ctx.beginPath();
            this.ctx.moveTo(0, -size);
            this.ctx.lineTo(0, 0);
            this.ctx.lineTo(-facet, 0);
            this.ctx.closePath();
            this.ctx.fill();
        } catch (error) {
            this.drawFallbackCircle(colors[0], size);
        }
        
        this.ctx.restore();
    }

    // Fallback shape for error cases
    drawFallbackCircle(color, size) {
        this.ctx.fillStyle = color;
        this.ctx.beginPath();
        this.ctx.arc(0, 0, size, 0, Math.PI * 2);
        this.ctx.fill();
    }

    // Pre-calculate elements for better performance
    generateElements(colors) {
        const numElements = KALEIDOSCOPE_CONFIG.MIN_ELEMENTS + 
                          Math.floor(Math.random() * KALEIDOSCOPE_CONFIG.MAX_ADDITIONAL_ELEMENTS);
        const elements = [];
        
        for (let i = 0; i < numElements; i++) {
            elements.push({
                distance: Math.random() * this.radius * KALEIDOSCOPE_CONFIG.RADIUS_MULTIPLIER,
                angle: Math.random() * KALEIDOSCOPE_CONFIG.SEGMENT_ANGLE,
                size: KALEIDOSCOPE_CONFIG.MIN_SIZE + Math.random() * KALEIDOSCOPE_CONFIG.MAX_SIZE,
                rotation: Math.random() * Math.PI * 2,
                shape: this.shapes[Math.floor(Math.random() * this.shapes.length)]
            });
        }
        
        return elements;
    }

    // Optimized element drawing
    drawElement(element, colors) {
        const x = Math.cos(element.angle) * element.distance;
        const y = Math.sin(element.angle) * element.distance;
        const mirrorY = -y;
        
        // Draw original and mirrored element
        switch (element.shape) {
            case 'petal':
                this.drawPetal(x, y, element.size, element.rotation, colors);
                this.drawPetal(x, mirrorY, element.size, element.rotation, colors);
                break;
            case 'star':
                this.drawStar(x, y, element.size, element.rotation, colors);
                this.drawStar(x, mirrorY, element.size, element.rotation, colors);
                break;
            case 'diamond':
                this.drawDiamond(x, y, element.size, element.rotation, colors);
                this.drawDiamond(x, mirrorY, element.size, element.rotation, colors);
                break;
        }
    }

    // Main generation method - optimized
    generate() {
        try {
            console.log('Generating optimized kaleidoscope...');
            
            // Update dimensions in case canvas was resized
            this.updateDimensions();
            
            // Clear canvas efficiently
            this.ctx.clearRect(0, 0, this.width, this.height);
            this.ctx.fillStyle = '#000';
            this.ctx.fillRect(0, 0, this.width, this.height);

            const colors = this.getColorPalette();
            const elements = this.generateElements(colors);
            
            // Setup transformation once
            this.ctx.save();
            this.ctx.translate(this.centerX, this.centerY);

            // Draw all segments efficiently
            for (let segment = 0; segment < KALEIDOSCOPE_CONFIG.SEGMENTS; segment++) {
                this.ctx.save();
                this.ctx.rotate(segment * this.segmentAngle);
                
                // Draw all elements in this segment
                elements.forEach(element => this.drawElement(element, colors));
                
                this.ctx.restore();
            }

            this.ctx.restore();

            // Add center decoration and outer ring
            this.addDecorations(colors);

            console.log('Optimized kaleidoscope generated successfully');
            return true;
            
        } catch (error) {
            console.error('Error generating kaleidoscope:', error);
            return false;
        }
    }

    // Separated decoration method
    addDecorations(colors) {
        try {
            // Center medallion
            const centerGradient = this.createGradient(this.centerX, this.centerY, 30, colors);
            this.ctx.fillStyle = centerGradient;
            this.ctx.beginPath();
            this.ctx.arc(this.centerX, this.centerY, 25, 0, Math.PI * 2);
            this.ctx.fill();

            // Outer ring
            this.ctx.strokeStyle = colors[Math.floor(colors.length / 2)] + '40';
            this.ctx.lineWidth = 4;
            this.ctx.beginPath();
            this.ctx.arc(this.centerX, this.centerY, this.radius - 5, 0, Math.PI * 2);
            this.ctx.stroke();
        } catch (error) {
            console.log('Decoration drawing failed, skipping');
        }
    }
}

// Optimized global instance management
let kaleidoscopeInstance = null;

// Main generation function with better error handling
window.generateKaleidoscope = (canvasId) => {
    return new Promise((resolve) => {
        setTimeout(() => {
            try {
                const canvas = document.getElementById(canvasId);
                if (!canvas) {
                    console.error('Canvas element not found');
                    resolve(false);
                    return;
                }

                // Ensure canvas dimensions
                canvas.width = 400;
                canvas.height = 400;

                // Create or update instance
                if (!kaleidoscopeInstance || kaleidoscopeInstance.canvas !== canvas) {
                    kaleidoscopeInstance = new OptimizedKaleidoscope(canvas);
                }

                const result = kaleidoscopeInstance.generate();
                resolve(result);
                
            } catch (error) {
                console.error('Error in kaleidoscope generation:', error);
                resolve(false);
            }
        }, KALEIDOSCOPE_CONFIG.GENERATION_DELAY);
    });
};

// Blazor interop functions
window.initializeKaleidoscope = (canvasId, width, height) => {
    console.log('Initializing optimized kaleidoscope...');
    return window.generateKaleidoscope(canvasId);
};

window.regenerateKaleidoscope = () => {
    console.log('Regenerating optimized kaleidoscope...');
    return window.generateKaleidoscope('kaleidoscopeCanvas');
};

// Initialize when ready
waitForBlazorServer(() => {
    console.log('Optimized kaleidoscope generator ready for Blazor Server');
});

console.log('Optimized kaleidoscope generator loaded');