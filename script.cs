document.addEventListener("DOMContentLoaded", function () {
    loadPosts();
});

// Function to switch between Home and Explore
function showHome() {
    document.getElementById("home-page").classList.remove("hidden");
    document.getElementById("explore-page").classList.add("hidden");
}

function showExplore() {
    document.getElementById("home-page").classList.add("hidden");
    document.getElementById("explore-page").classList.remove("hidden");
}
 function homePage() {
    window.location.href = 'BeeGreatV2.2.html';
    //window.location.href = 'home2.html';  // Redirect to camera.html page
 }
// AI-generated supportive messages
const aiMessages = [
    "🌟 You're doing amazing, keep pushing forward!",
    "💡 Remember: Every step forward is progress!",
    "🔥 Your potential is limitless, believe in yourself!",
    "🌈 The world needs your unique spark. Keep shining!",
    "✨ Mistakes help you grow, keep learning and improving!",
    "💪 You are stronger than you think. Keep going!",
    "🚀 Dream big, work hard, and make it happen!",
    "💖 Someone out there is inspired by you, don’t stop now!",
    "😊 A little progress each day adds up to big results!"
];

// Function to generate AI messages when button is clicked
function generateAIMessages() {
    let exploreContainer = document.getElementById("ai-messages-container");
    
    // Select a random message from the list
    let randomMessage = aiMessages[Math.floor(Math.random() * aiMessages.length)];

    let messageDiv = document.createElement("div");
    messageDiv.classList.add("bot-message");
    messageDiv.innerHTML = `
        <h3>Fellow User</h3>
        <p>${randomMessage}</p>
        <div class="post-buttons">
            <i class="fas fa-heart" onclick="likePost()"></i>
            <i class="fas fa-comment"></i>
        </div>
    `;

    exploreContainer.appendChild(messageDiv);
}

// Function to add a new tweet (post)
function addPost() {
    let postContent = document.getElementById("postContent").value;
    if (postContent.trim() === "") return;

    let posts = JSON.parse(localStorage.getItem("posts")) || [];
    let newPost = {
        id: Date.now(),
        content: postContent,
        likes: 0,
        comments: []
    };

    posts.unshift(newPost); // Adds the newest post at the top
    localStorage.setItem("posts", JSON.stringify(posts));
    document.getElementById("postContent").value = "";
    displayPosts();
}

// Function to display tweets
function displayPosts() {
    let postsContainer = document.getElementById("posts-container");
    postsContainer.innerHTML = "";

    let posts = JSON.parse(localStorage.getItem("posts")) || [];

    posts.forEach(post => {
        let postDiv = document.createElement("div");
        postDiv.classList.add("post");

        postDiv.innerHTML = `
            <div class="post-content">
                <h3>Anonymous User</h3>
                <p>${post.content}</p>
                <div class="post-buttons">
                    <i class="fas fa-heart" onclick="likePost(${post.id})">${post.likes}</i>
                    <i class="fas fa-comment" onclick="toggleComment(${post.id})"></i>
                    <i class="fas fa-trash-alt delete-btn" onclick="deletePost(${post.id})"></i>
                </div>
                <div class="comment-section hidden" id="comments-${post.id}">
                    ${post.comments.map(comment => `<div class="comment">${comment}</div>`).join("")}
                    <div class="comment-input">
                        <input type="text" id="commentInput-${post.id}" placeholder="Reply...">
                        <button onclick="addComment(${post.id})">Post</button>
                    </div>
                </div>
            </div>
        `;

        postsContainer.appendChild(postDiv);
    });
}

// Function to delete a post
function deletePost(postId) {
    let posts = JSON.parse(localStorage.getItem("posts")) || [];
    posts = posts.filter(post => post.id !== postId);
    localStorage.setItem("posts", JSON.stringify(posts));
    displayPosts();
}

// Function to like a post
function likePost(postId) {
    let posts = JSON.parse(localStorage.getItem("posts")) || [];
    let post = posts.find(p => p.id === postId);

    if (post) {
        post.likes += 1;
        localStorage.setItem("posts", JSON.stringify(posts));
        displayPosts();
    }
}

// Function to toggle comments
function toggleComment(postId) {
    document.getElementById(`comments-${postId}`).classList.toggle("hidden");
}

// Function to add a comment
function addComment(postId) {
    let commentInput = document.getElementById(`commentInput-${postId}`);
    let commentText = commentInput.value.trim();

    if (commentText === "") return;

    let posts = JSON.parse(localStorage.getItem("posts")) || [];
    let post = posts.find(p => p.id === postId);

    if (post) {
        post.comments.push(commentText);
        localStorage.setItem("posts", JSON.stringify(posts));
        commentInput.value = "";
        displayPosts();
    }
}

// Load posts on page load
function loadPosts() {
    displayPosts();
}
