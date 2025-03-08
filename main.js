// Select elements
const journalMenu = document.getElementById("journal-menu");
const journalContainer = document.getElementById("journal-container");
const backBtn = document.getElementById("back-btn");
const journalTitle = document.getElementById("journal-title");
const journalText = document.getElementById("journal-text");

// Dummy journal data
const journals = {
    1: { title: "Journal 1", text: "This is the content of Journal 1." },
    2: { title: "Journal 2", text: "This is the content of Journal 2." },
    3: { title: "Journal 3", text: "This is the content of Journal 3." }
};

// Open Journal
function openJournal(journalId) {
    journalMenu.classList.add("hidden");
    journalContainer.classList.remove("hidden");
    journalTitle.innerText = journals[journalId].title;
    journalText.innerText = journals[journalId].text;
}
function homePage() {
    window.location.href = 'BeeGreatV2.2.html';
    //window.location.href = 'home2.html';  // Redirect to camera.html page
}
// Go Back to Menu
backBtn.addEventListener("click", () => {
    journalContainer.classList.add("hidden");
    journalMenu.classList.remove("hidden");
});
