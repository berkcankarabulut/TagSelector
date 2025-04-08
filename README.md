  <h3>TagSelector (Unity Tag Selection System)</h3>
    <p>Custom property drawer that enables <strong>convenient tag selection</strong> in the Unity Inspector.</p>
    <ul>
        <li><strong>Single Tag Selection:</strong> Select Unity tags from a dropdown menu.</li>
        <li><strong>Tag List Support:</strong> Manage arrays/lists of Unity tags with a compact UI.</li>
        <li><strong>Usage:</strong> Simply add the <code>[TagSelector]</code> attribute to any string or string array/list field.</li>
    </ul>
    <pre><code>[SerializeField, TagSelector] protected string targetTag;
[SerializeField, TagSelector] protected List< string > requiredTags;
    </code></pre>
    <p>Makes working with Unity's tag system more intuitive, eliminating typos and improving workflow efficiency.</p>
